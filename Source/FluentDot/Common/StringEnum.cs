/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Common
{
    /// <summary>
    /// An enum that represents a string value.
    /// </summary>
    public class StringEnum : AbstractTypedEnum<string> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="StringEnum"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public StringEnum(string value)
            : base(value)
        {
            // Nothing to do.
        }

        #endregion

        #region Object Members

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString() {
            return Value;
        }

        #endregion
    }
}