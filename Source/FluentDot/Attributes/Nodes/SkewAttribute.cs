/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Nodes {

    /// <summary>
    /// An attribute that applies a skew factor to a node with shape polygon.
    /// </summary>
    public class SkewAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="SkewAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public SkewAttribute(double value) : base("skew", value, true)
        {
            if ((value < -100) || (value > 100))
            {
                throw new ArgumentOutOfRangeException("value", "Skew must be within the range -100 to 100");
            }
        }

        #endregion
    }
}
