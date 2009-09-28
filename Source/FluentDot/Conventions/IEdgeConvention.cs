/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Edges;

namespace FluentDot.Conventions
{
    /// <summary>
    /// A convention that can be applied on edges.
    /// </summary>
    public interface IEdgeConvention : IConvention
    {
        /// <summary>
        /// Determines whether the configuration in the Apply method should be applied to this edge instance.
        /// </summary>
        /// <param name="nodeInfo">Information on the edge currently being inspected.</param>
        /// <returns>An indication of whether we should proceed with configuring this edge instance.</returns>
        bool ShouldApply(IEdgeInfo nodeInfo);

        /// <summary>
        /// Applies the specified edge configuration to the edge in question.
        /// </summary>
        /// <param name="edgeInfo">Information on the edge currently being inspected.</param>
        /// <param name="edge">The expression for edge configuration.</param>
        void Apply(IEdgeInfo edgeInfo, IEdgeExpression edge);
    }
}
