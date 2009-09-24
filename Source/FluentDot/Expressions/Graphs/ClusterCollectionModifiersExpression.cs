/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// A concrete implementation of a <see cref="IClusterCollectionModifiersExpression{T}"/>
    /// </summary>
    /// <typeparam name="T">The type of parent expression.</typeparam>
    public class ClusterCollectionModifiersExpression<T> : IClusterCollectionModifiersExpression<T> {

        #region Globals

        private readonly IGraph graph;
        private readonly T parent;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterCollectionModifiersExpression{T}"/> class.
        /// </summary>
        /// <param name="graph">The parent graph.</param>
        /// <param name="parent">The parent expression instance.</param>
        public ClusterCollectionModifiersExpression(IGraph graph, T parent)
        {
            this.graph = graph;
            this.parent = parent;
        }

        #endregion

        #region IClusterCollectionModifiersExpression Members

        /// <summary>
        /// Adds clusters to the graph.
        /// </summary>
        /// <param name="addExpression">The add expression to modify.</param>
        /// <returns>The parent expression instance.</returns>
        public T Add(System.Action<IClusterCollectionAddExpression> addExpression)
        {
            if (addExpression != null)
            {
                var expression = new ClusterCollectionAddExpression(graph);
                addExpression(expression);
            }

            return parent;
        }

        #endregion
    }
}