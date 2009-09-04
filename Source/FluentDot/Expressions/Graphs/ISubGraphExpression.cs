/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

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
        /// Edits the node collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the node collection.</value>
        INodeCollectionModifiersExpression<IClusterExpression> Nodes { get; }

        /// <summary>
        /// Edits the edge collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the edge collection.</value>
        IEdgeCollectionModifiersExpression<IClusterExpression> Edges { get; }
    }
}