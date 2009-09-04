/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// A concrete implementation of a <see cref="INodeCollectionAddExpression"/>.
    /// </summary>
    public class NodeCollectionAddExpression : INodeCollectionAddExpression {
        
        #region Globals

        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeCollectionAddExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public NodeCollectionAddExpression(IGraph graph)
        {
            this.graph = graph;
        }

        #endregion

        #region INodeCollectionExpression Members

        /// <summary>
        /// Adds a node with the specified name to the graph.
        /// </summary>
        /// <param name="name">The name of the node to create.</param>
        /// <returns>
        /// A node expression for configuring the node.
        /// </returns>
        public INodeExpression WithName(string name) {
            var node = new GraphNode(name);
            graph.AddNode(node);

            var expression = new NodeExpression(node);
            return expression;
        }

        #endregion
    }
}