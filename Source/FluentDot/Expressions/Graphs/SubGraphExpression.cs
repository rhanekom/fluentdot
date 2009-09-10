/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Graphs;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Graphs {
    /// <summary>
    /// A concrete implementation of a <see cref="ISubGraphExpression"/>.
    /// </summary>
    public class SubGraphExpression : ISubGraphExpression {

        #region Globals

        private readonly SubGraph subGraph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="SubGraphExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public SubGraphExpression(IGraph graph) {
            subGraph = new SubGraph(graph);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the cluster.
        /// </summary>
        /// <value>The cluster.</value>
        public SubGraph SubGraph {
            get { return subGraph; }
        }

        #endregion

        #region ISubGraphExpression Members

        /// <summary>
        /// Specifies the rank type for this subgraph.
        /// </summary>
        /// <param name="rank">The rank of the subgraph.</param>
        /// <returns>The current expression instance.</returns>
        public ISubGraphExpression WithRank(RankType rank)
        {
            subGraph.Attributes.AddAttribute(new RankAttribute(rank));
            return this;
        }

        /// <summary>
        /// Edits the node collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the node collection.</value>
        public INodeCollectionModifiersExpression<ISubGraphExpression> Nodes {
            get { return new NodeCollectionModifiersExpression<ISubGraphExpression>(subGraph, this); }
        }

        /// <summary>
        /// Edits the edge collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the edge collection.</value>
        public IEdgeCollectionModifiersExpression<ISubGraphExpression> Edges {
            get { return new EdgeCollectionModifiersExpression<ISubGraphExpression>(subGraph, this); }
        }

        #endregion
    }
}