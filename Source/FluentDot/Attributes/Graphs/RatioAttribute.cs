/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute that sets the ratio or ratio behaviour of the graph.
    /// </summary>
    public class RatioAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RatioAttribute"/> class.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        public RatioAttribute(Ratio ratio)
            : base("ratio", ratio, true)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RatioAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public RatioAttribute(double value)
            : base("ratio", value, false)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("value", "Ration must be more than 0,");
            }
        }

        #endregion
    }
}
