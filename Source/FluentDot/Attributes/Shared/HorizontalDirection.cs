/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// Specifies the horizontal direction in which rectangle can be traversed.
    /// </summary>
    public class HorizontalDirection : StringEnum, IDotElement
    {
        #region Constants

        /// <summary>
        /// Represents a left to right horizontal order.
        /// </summary>
        public static readonly HorizontalDirection LeftToRight = new HorizontalDirection("L");

        /// <summary>
        /// Represents a right to left horizontal order.
        /// </summary>
        public static readonly HorizontalDirection RightToLeft = new HorizontalDirection("R");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="HorizontalDirection"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public HorizontalDirection(string value)
            : base(value)
        {

        }

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
            return Value;
        }

        #endregion
    }
}