/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Nodes {

    /// <summary>
    /// An attribute that specifies the number of sides of a node with shape polygon.
    /// </summary>
    public class SidesAttribute : AbstractDotAttribute<int>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="SidesAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public SidesAttribute(int value) : base("sides", value, false)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value", "Sides can not be less than 0.");
            }
        }

        #endregion
    }
}
