/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Nodes;
using FluentDot.Expressions.Shared;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// A concrete implementation of an <see cref="IDefaultsExpression"/>.
    /// </summary>
    public class DefaultsExpression : IDefaultsExpression {
        
        #region Globals

        private readonly IGraphExpression graphExpression;
        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultsExpression"/> class.
        /// </summary>
        /// <param name="graphExpression">The graph expression.</param>
        /// <param name="graph">The graph.</param>
        public DefaultsExpression(IGraphExpression graphExpression, IGraph graph)
        {
            this.graphExpression = graphExpression;
            this.graph = graph;
        }

        #endregion

        #region IDefaultsExpression Members

        /// <summary>
        /// Configures the default values for nodes.
        /// </summary>
        /// <value>The configuratione expression for nodes.</value>
        public IMultiActionExpression<INodeExpression, IGraphExpression> ForNodes {
            get {
                var node = new GraphNode("a");
                var nodeExpression = new NodeExpression(node);

                var expression = new MultiActionExpression<INodeExpression, IGraphExpression>(
                    nodeExpression, graphExpression, x => graph.SetNodeDefaults(node));
                return expression;
            }
        }

        /// <summary>
        /// Configures the default values for edges.
        /// </summary>
        /// <value>The configuratione expression for edges.</value>
        public IMultiActionExpression<IEdgeExpression, IGraphExpression> ForEdges {
            get {
                var edge = new DirectedEdge(null, null);
                var edgeExpression = new EdgeExpression(edge);

                var expression = new MultiActionExpression<IEdgeExpression, IGraphExpression>(
                    edgeExpression, graphExpression, x => graph.SetEdgeDefaults(edge));
                return expression;
            }
        }

        #endregion
    }
}