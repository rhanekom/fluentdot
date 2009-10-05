/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// An attribute for setting the arrow size on an edge arrow.
    /// </summary>
    public class ArrowSizeAttribute : AbstractDotAttribute<double> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowSizeAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ArrowSizeAttribute(double value)
            : base("arrowsize", value, false)
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid value specified.  The value for the arrow size must be positive and non-zero.", "value");
            }
        }

        #endregion
    }
}