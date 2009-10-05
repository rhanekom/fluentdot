/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Shared {

    /// <summary>
    /// Sets the number of peripheries used in polygonal shapes and cluster boundaries.
    /// </summary>
    public class PeripheriesAttribute : AbstractDotAttribute<int> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PeripheriesAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public PeripheriesAttribute(int value)
            : base("peripheries", value, false)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", "Peripheries can not be less than 0.");
            }
        }

        #endregion
    }
}
