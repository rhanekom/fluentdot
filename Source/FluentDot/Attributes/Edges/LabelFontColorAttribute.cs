/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// An attribute for setting the font color of the head and tail label on edges.
    /// </summary>
    public class LabelFontColorAttribute : AbstractDotAttribute {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelFontColorAttribute"/> class.
        /// </summary>
        /// <param name="fontColor">Color of the font.</param>
        public LabelFontColorAttribute(Color fontColor)
            : base("labelfontcolor", new ColorValue(fontColor), true) {

            }

        #endregion
    }
}