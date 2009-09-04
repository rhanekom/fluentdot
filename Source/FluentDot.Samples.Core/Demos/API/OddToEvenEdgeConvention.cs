/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Conventions;
using FluentDot.Expressions.Edges;

namespace FluentDot.Samples.Core.Demos.API
{
    public class OddToEvenEdgeConvention : IEdgeConvention
    {
        #region IEdgeConvention Members

        /// <summary>
        /// Determines whether the configuration in the Apply method should be applied to this edge instance.
        /// </summary>
        /// <param name="nodeInfo">Information on the edge currently being inspected.</param>
        /// <returns>
        /// An indication of whether we should proceed with configuring this edge instance.
        /// </returns>
        public bool ShouldApply(IEdgeInfo nodeInfo)
        {
            var from = (int) nodeInfo.FromNode.Tag;
            var to = (int)nodeInfo.ToNode.Tag;

            // Apply this convention on edges from odd nodes to even nodes.
            return (from.IsOdd() && (to.IsEven()));
        }

        public void Apply(IEdgeInfo edgeInfo, IEdgeExpression edge)
        {
            edge.WithLabel("Odd to Even").WithColor(Color.Blue);
        }

        #endregion
    }
}