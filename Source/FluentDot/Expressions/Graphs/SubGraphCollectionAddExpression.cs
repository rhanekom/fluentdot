/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Graphs {
    /// <summary>
    /// A concrete implementation of a <see cref="ISubGraphCollectionAddExpression"/>.
    /// </summary>
    public class SubGraphCollectionAddExpression : ISubGraphCollectionAddExpression {
        #region Globals

        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="SubGraphCollectionAddExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public SubGraphCollectionAddExpression(IGraph graph) {
            this.graph = graph;
        }

        #endregion

        #region ISubGraphCollectionAddExpression Members

        /// <summary>
        /// Adds a subgraph with the specified name to the graph.
        /// </summary>
        /// <param name="name">The name of the subgraph to create.</param>
        /// <returns>
        /// A subgraph expression for configuring the graph.
        /// </returns>
        public ISubGraphExpression WithName(string name) {
            var expression = new SubGraphExpression(graph);
            expression.SubGraph.Name = name;
            graph.AddSubGraph(expression.SubGraph);
            return expression;
        }

        #endregion
    }
}