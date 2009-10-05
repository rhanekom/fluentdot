/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Common;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// A type of ratio that specifies the ratio or ratio behaviour of a graph.
    /// </summary>
    public class RatioType : IDotElement
    {
        #region Globals

        private readonly Ratio ratio;
        private readonly double value;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RatioAttribute"/> class.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        public RatioType(Ratio ratio)
        {
            this.ratio = ratio;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RatioType"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public RatioType(double value)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("value", "Ratio must be more than 0,");
            }

            this.value = value;
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
            if (ratio != null)
            {
                return ratio.ToDot();
            }
            
            return value.ToString();
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
            var other = obj as RatioType;

            if (other == null)
            {
                return false;
            }

            return Equals(other.ratio, ratio) && Equals(other.value, value);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((ratio != null ? ratio.GetHashCode() : 0)*397) ^ value.GetHashCode();
            }
        }

        #endregion
    }
}
