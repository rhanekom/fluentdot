/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// A concrete implementation of a <see cref="IEdgeDestinationSelectionExpression"/>.
    /// </summary>
    public class EdgeDestinationSelectionExpression : IEdgeDestinationSelectionExpression {
        
        #region Globals

        private readonly IGraph graph;
        private readonly INodeTarget fromNode;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDestinationSelectionExpression"/> class.
        /// </summary>
        /// <param name="fromNode">The from node to add to the edge.</param>
        /// <param name="graph">The graph.</param>
        public EdgeDestinationSelectionExpression(INodeTarget fromNode, IGraph graph)
        {
            this.fromNode = fromNode;
            this.graph = graph;
        }

        #endregion

        #region IEdgeDestinationSelectionExpression Members

        /// <summary>
        /// Selects a node by name to be the destination of the edge.
        /// </summary>
        /// <param name="name">The name of the node to choose as the source of the edge.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression NodeWithName(string name) {
            var toNode = graph.NodeLookup.GetNodeByName(name);

            if (toNode == null) {
                throw new ArgumentException("Could not find node with name " + name, "name");
            }

            return AddNode(new NodeTarget(toNode));
        }

        /// <summary>
        /// Selects a node by tag to be the destination of the edge.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag to match.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression NodeWithTag<T>(T tag) {
            var toNode = graph.NodeLookup.GetNodeByTag(tag);

            if (toNode == null)
            {
                throw new ArgumentException("Could not find node with the specified tag.", "tag");
            }

            return AddNode(new NodeTarget(toNode));
        }

        /// <summary>
        /// Selects a record by name to be the source of the edge.
        /// </summary>
        /// <param name="name">The name of the record to choose as the source of the edge.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression RecordWithName(string name, string elementName) {
            var toNode = graph.NodeLookup.GetNodeByName(name);

            if (toNode == null) {
                throw new ArgumentException("Could not find node with name " + name, "name");
            }

            var recordNode = toNode as IRecordNode;

            if (recordNode == null) {
                throw new ArgumentException("Node " + name + " is not a record node.", "name");
            }

            if (!recordNode.ElementTracker.ContainsElement(elementName)) {
                throw new ArgumentException("Invalid element name - the specified name could not be found.", "elementName");
            }

            return AddNode(new NodeTarget(recordNode, elementName));
        }

        /// <summary>
        /// Selects a record by tag to be the source of the edge.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag to match.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression RecordWithTag<T>(T tag, string elementName) {

            var toNode = graph.NodeLookup.GetNodeByTag(tag);

            if (toNode == null) {
                throw new ArgumentException("Could not find node with tag " + tag, "tag");
            }

            var recordNode = toNode as IRecordNode;

            if (recordNode == null) {
                throw new ArgumentException("Node with tag " + tag + " is not a record node.", "tag");
            }

            if (!recordNode.ElementTracker.ContainsElement(elementName)) {
                throw new ArgumentException("Invalid element name - the specified name could not be found.", "elementName");
            }

            return AddNode(new NodeTarget(recordNode, elementName));
        }

        /// <summary>
        /// Selects a node by creating a new one to be the destination of the edge.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression NewNode(string nodeName)
        {
            return NewNode(nodeName, null);
        }

        /// <summary>
        /// Selects a node by creating a new one to be the destination of the edge.
        /// </summary>
        /// <param name="nodeName">Name of the node.</param>
        /// <param name="nodeConfiguration">The node configuration to apply to the node.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression NewNode(string nodeName, Action<INodeExpression> nodeConfiguration)
        {
            var toNode = new GraphNode(nodeName);
            graph.AddNode(toNode);
            
            if (nodeConfiguration != null)
            {
                var expression = new NodeExpression(toNode);
                nodeConfiguration(expression); 
            }

            return AddNode(new NodeTarget(toNode));
        }

        #endregion

        #region Private Members

        private IEdgeExpression AddNode(INodeTarget toNode) {

            if (toNode == null) {
                throw new ArgumentException("Invalid node - the specified graph node could not be found.", "toNode");
            }

            IEdge edge;

            if (graph.Type == GraphType.Directed) 
            {
                edge = new DirectedEdge(fromNode, toNode);
            } 
            else
            {
                edge = new UndirectedEdge(fromNode, toNode);
            }

            graph.AddEdge(edge);

            return new EdgeExpression(edge);
        }

        #endregion
    }
}