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
    /// An attribute that defines the color of the node or edge.
    /// </summary>
    public class ColorAttribute : AbstractDotAttribute<ColorValue> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ColorAttribute(Color value)
            : base("color", new ColorValue(value), true)
        {
            // Nothing to do.
        }

        #endregion
    }
}