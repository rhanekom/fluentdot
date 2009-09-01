/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using FluentDot.Common;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// A color value.
    /// </summary>
    public class ColorValue : IDotElement {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorValue"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public ColorValue(Color color)
        {
            Value = color;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public Color Value { get; private set; }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot()
        {
            return Value == Color.Transparent
                       ? "transparent"
                       : String.Format("#{0}{1}{2}",
                                       Convert.ToString(Value.R, 16).PadLeft(2, '0'),
                                       Convert.ToString(Value.G, 16).PadLeft(2, '0'),
                                       Convert.ToString(Value.B, 16).PadLeft(2, '0')
                             );
        }

        #endregion

        #region Object Members

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj)
        {
            var other = obj as ColorValue;
            return other != null && Value.Equals(other.Value);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        #endregion
    }
}