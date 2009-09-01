/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Nodes;

namespace FluentDot.Conventions
{
    /// <summary>
    /// A convention setter for nodes.
    /// </summary>
    public interface INodeConvention : IConvention
    {
        /// <summary>
        /// Determines whether the configuration in the Apply method should be applied to this node instance.
        /// </summary>
        /// <param name="nodeInfo">Information on the node currently being inspected.</param>
        /// <returns></returns>
        bool ShouldApply(INodeInfo nodeInfo);

        /// <summary>
        /// Applies the specified node configuration to the node in question.
        /// </summary>
        /// <param name="nodeInfo">Information on the node currently being inspected.</param>
        /// <param name="nodeConfig">The expression for node configuration.</param>
        void Apply(INodeInfo nodeInfo, INodeExpression nodeConfig);
    }
}
