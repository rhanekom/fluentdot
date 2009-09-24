/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Graphs;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// The root expression for building clusters.
    /// </summary>
    public interface ISubGraphExpression
    {
        /// <summary>
        /// Specifies the rank type for this subgraph.
        /// </summary>
        /// <param name="rank">The rank of the subgraph.</param>
        /// <returns>The current expression instance.</returns>
        ISubGraphExpression WithRank(RankType rank);

        /// <summary>
        /// Edits the sub graph collection for this subgraph.
        /// </summary>
        /// <value>The expression for acting upon the subgraph collection.</value>
        ISubGraphCollectionModifiersExpression<ISubGraphExpression> SubGraphs { get; }
        
        /// <summary>
        /// Edits the node collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the node collection.</value>
        INodeCollectionModifiersExpression<ISubGraphExpression> Nodes { get; }

        /// <summary>
        /// Edits the edge collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the edge collection.</value>
        IEdgeCollectionModifiersExpression<ISubGraphExpression> Edges { get; }
    }
}