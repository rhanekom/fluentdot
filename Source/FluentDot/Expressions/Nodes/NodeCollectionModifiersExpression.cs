/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// A concrete implementation of a <see cref="INodeCollectionModifiersExpression{T}"/>.
    /// </summary>
    public class NodeCollectionModifiersExpression<T> : INodeCollectionModifiersExpression<T> {

        #region Globals

        private readonly IGraph graph;
        private readonly T parent;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeCollectionModifiersExpression{T}"/> class.
        /// </summary>
        /// <param name="graph">The graph to modify.</param>
        /// <param name="parent">The parent expression to return to.s</param>
        public NodeCollectionModifiersExpression(IGraph graph, T parent)
        {
            this.graph = graph;
            this.parent = parent;
        }

        #endregion

        #region INodeCollectionModifiersExpression<T> Members

        /// <summary>
        /// Adds nodes to the graph.
        /// </summary>
        /// <param name="addExpression">The add expression to modify.</param>
        public T Add(Action<INodeCollectionAddExpression> addExpression) {
            if (addExpression != null)
            {
                addExpression(new NodeCollectionAddExpression(graph));
            }

            return parent;
        }

        /// <summary>
        /// Adds record nodes to the graph.
        /// </summary>
        /// <param name="addExpression">The add expression to modify.</param>
        /// <returns>The parent expression instance.</returns>
        public T AddRecord(Action<IRecordCollectionAddExpression> addExpression)
        {
            if (addExpression != null)
            {
                addExpression(new RecordCollectionAddExpression(graph));
            }

            return parent;
        }

        #endregion
    }
}