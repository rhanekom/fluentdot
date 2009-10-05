/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that specifies how much, in inches, to extend the drawing area around the minimal area needed to draw the graph.
    /// </summary>
    public class PadAttribute : AbstractDotAttribute<PointValue>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PadAttribute"/> class.
        /// </summary>
        /// <param name="x">The x padding value.</param>
        /// <param name="y">The y padding value.</param>
        public PadAttribute(float x, float y) : base("pad", new PointValue(x, y), false)
        {
            
        }

        #endregion
    }
}
