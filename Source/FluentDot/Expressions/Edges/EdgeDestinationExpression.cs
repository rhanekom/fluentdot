/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities;
using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// A concrete implementation of a <see cref="IEdgeDestinationExpression"/>.
    /// </summary>
    public class EdgeDestinationExpression : IEdgeDestinationExpression {
        
        #region Globals

        private readonly INodeTarget fromNode;
        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDestinationExpression"/> class.
        /// </summary>
        /// <param name="fromNode">The initial node for the edge.</param>
        /// <param name="graph">The graph.</param>
        public EdgeDestinationExpression(INodeTarget fromNode, IGraph graph)
        {
            this.fromNode = fromNode;
            this.graph = graph;
        }
        
        #endregion

        #region IEdgeDestinationExpression Members

        /// <summary>
        /// Gets an expression to select the destination node of the edge.
        /// </summary>
        /// <value>An expression to select the destination node of the edge.</value>
        public IEdgeDestinationSelectionExpression To {
            get { return new EdgeDestinationSelectionExpression(fromNode, graph); }
        }

        #endregion
    }
}