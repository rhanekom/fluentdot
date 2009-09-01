/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// A concrete implementaiton of a <see cref="IEdgeCollectionAddExpression"/>
    /// </summary>
    public class EdgeCollectionAddExpression : IEdgeCollectionAddExpression {
        
        #region Globals

        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeCollectionAddExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public EdgeCollectionAddExpression(IGraph graph) {
            this.graph = graph;
        }

        #endregion

        #region IEdgeCollectionAddExpression Members

        /// <summary>
        /// Specifies where the edge should be emanating from.
        /// </summary>
        /// <value>
        /// An expression to specify where the edge should be emanating from.
        /// </value>
        public IEdgeSourceExpression From {
            get { return new EdgeSourceExpression(graph); }
        }

        #endregion
    }
}