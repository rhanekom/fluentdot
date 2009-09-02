/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// A concrete implementation of a <see cref="IEdgeSourceExpression"/>.
    /// </summary>
    public class EdgeSourceExpression : IEdgeSourceExpression {
        
        #region Globals

        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeSourceExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public EdgeSourceExpression(IGraph graph)
        {
            this.graph = graph;
        }

        #endregion

        #region IEdgeSourceExpression Members

        /// <summary>
        /// Selects a node by name to be the source of the edge.
        /// </summary>
        /// <param name="name">The name of the node to choose as the source of the edge.</param>
        /// <returns></returns>
        public IEdgeDestinationExpression NodeWithName(string name) {
            var fromNode = graph.NodeLookup.GetNodeByName(name);

            if (fromNode == null)
            {
                throw new ArgumentException("Could not find node with name " + name, "name");
            }

            return new EdgeDestinationExpression(new NodeTarget(fromNode), graph);
        }

        /// <summary>
        /// Selects a node by tag to be the source of the edge.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag to match.</param>
        /// <returns></returns>
        public IEdgeDestinationExpression NodeWithTag<T>(T tag) {
            var fromNode = graph.NodeLookup.GetNodeByTag(tag);

            if (fromNode == null) {
                throw new ArgumentException("Could not find node with the specified tag.", "tag");
            }

            return new EdgeDestinationExpression(new NodeTarget(fromNode), graph);
        }

        /// <summary>
        /// Selects a record by name to be the source of the edge.
        /// </summary>
        /// <param name="name">The name of the record to choose as the source of the edge.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeDestinationExpression RecordWithName(string name, string elementName)
        {
            var fromNode = graph.NodeLookup.GetNodeByName(name);

            if (fromNode == null) {
                throw new ArgumentException("Could not find node with name " + name, "name");
            }

            var recordNode = fromNode as IRecordNode;

            if (recordNode == null)
            {
                throw new ArgumentException("Node " + name + " is not a record node.", "name");
            }

            if (!recordNode.ElementTracker.ContainsElement(elementName))
            {
                throw new ArgumentException("Invalid element name - the specified name could not be found.", "elementName");
            }

            return new EdgeDestinationExpression(new NodeTarget(recordNode, elementName), graph);
        }

        /// <summary>
        /// Selects a record by tag to be the source of the edge.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag to match.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeDestinationExpression RecordWithTag<T>(T tag, string elementName) {

            var fromNode = graph.NodeLookup.GetNodeByTag(tag);

            if (fromNode == null) {
                throw new ArgumentException("Could not find node with tag " + tag, "tag");
            }

            var recordNode = fromNode as IRecordNode;

            if (recordNode == null) {
                throw new ArgumentException("Node with tag " + tag + " is not a record node.", "tag");
            }

            if (!recordNode.ElementTracker.ContainsElement(elementName)) {
                throw new ArgumentException("Invalid element name - the specified name could not be found.", "elementName");
            }

            return new EdgeDestinationExpression(new NodeTarget(recordNode, elementName), graph);
        }

        /// <summary>
        /// Selects a node by creating a new one to be the source of the edge.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeDestinationExpression NewNode(string nodeName)
        {
            return NewNode(nodeName, null);
        }

        /// <summary>
        /// Selects a node by creating a new one to be the source of the edge.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="nodeConfiguration">The node configuration to apply to the node.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeDestinationExpression NewNode(string nodeName, Action<INodeExpression> nodeConfiguration)
        {
            var fromNode = new GraphNode(nodeName);
            graph.AddNode(fromNode);

            if (nodeConfiguration != null) {
                var expression = new NodeExpression(fromNode);
                nodeConfiguration(expression);
            }

            return new EdgeDestinationExpression(new NodeTarget(fromNode), graph);
        }

        #endregion
    }
}