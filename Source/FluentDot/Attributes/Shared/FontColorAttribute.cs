/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute for setting the font color of nodes, graphs, and edges.
    /// </summary>
    public class FontColorAttribute : AbstractDotAttribute<ColorValue> {

        #region Construction


        /// <summary>
        /// Initializes a new instance of the <see cref="FontColorAttribute"/> class.
        /// </summary>
        /// <param name="fontColor">Color of the font.</param>
        public FontColorAttribute(Color fontColor)
            : base("fontcolor", new ColorValue(fontColor), true) {

            }

        #endregion
    }
}