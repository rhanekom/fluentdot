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
    /// A concrete implementation of a <see cref="IEdgeCollectionModifiersExpression{T}"/>
    /// </summary>
    public class EdgeCollectionModifiersExpression<T> : IEdgeCollectionModifiersExpression<T> {

        #region Globals

        private readonly IGraph graph;
        private readonly T parent;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeCollectionModifiersExpression{T}"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="parent">The parent expression instance.</param>
        public EdgeCollectionModifiersExpression(IGraph graph, T parent)
        {
            this.graph = graph;
            this.parent = parent;
        }

        #endregion

        #region IEdgeCollectionModifiersExpression Members

        /// <summary>
        /// Adds nodes configured by the specified add expression.
        /// </summary>
        /// <param name="addExpression">The add expression.</param>
        /// <returns>The current expression instance.</returns>
        public T Add(System.Action<IEdgeSourceExpression> addExpression) {

            if (addExpression != null)
            {
                addExpression(new EdgeSourceExpression(graph));
            }

            return parent;
        }

        #endregion
    }
}