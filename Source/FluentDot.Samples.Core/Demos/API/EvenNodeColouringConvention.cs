/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes.Nodes;
using FluentDot.Conventions;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Samples.Core.Demos.API
{
    public class EvenNodeColouringConvention : INodeConvention
    {
        #region INodeConvention Members

        /// <summary>
        /// Determines whether the configuration in the Apply method should be applied to this node instance.
        /// </summary>
        /// <param name="nodeInfo">Information on the node currently being inspected.</param>
        /// <returns></returns>
        public bool ShouldApply(INodeInfo nodeInfo)
        {
            var tag = (int) nodeInfo.Tag;
            return tag.IsEven();
        }

        /// <summary>
        /// Applies the specified node configuration to the node in question.
        /// </summary>
        /// <param name="nodeInfo">Information on the node currently being inspected.</param>
        /// <param name="nodeConfig">The expression for node configuration.</param>
        public void Apply(INodeInfo nodeInfo, INodeExpression nodeConfig)
        {
            nodeConfig.WithFillColor(Color.Gainsboro).WithStyle(NodeStyle.Filled);
        }

        #endregion
    }
}