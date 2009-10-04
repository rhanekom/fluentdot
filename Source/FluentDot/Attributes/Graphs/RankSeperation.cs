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
    /// Rank seperation between nodes in ranks.
    /// </summary>
    public class RankSeperation : IDotElement
    {
        #region Globals

        private readonly double? inches;
        private readonly bool equal;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RankSeperation"/> class.
        /// </summary>
        /// <param name="inches">The inches.</param>
        /// <param name="equal">The equal.</param>
        public RankSeperation(double? inches, bool equal)
        {
            if  ((inches == null) && (!equal))
            {
                throw new ArgumentException("Either inches needs to be specified, or the rank seperation must be set to equally.");
            }

            if ((inches != null) && (inches.Value < 0.02))
            {
                throw new ArgumentOutOfRangeException("inches", "Rank seperation inches can not be less than 0.02.");
            }

            this.inches = inches;
            this.equal = equal;
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
            if ((inches != null) && (equal))
            {
                return String.Format("{0} equally", inches);
            }
            
            if (inches != null)
            {
                return inches.Value.ToString();
            }

            return "equally";
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
            var other = obj as RankSeperation;

            if (other == null)
            {
                return false;
            }

            return inches == other.inches && equal == other.equal;
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
                return ((inches.HasValue ? inches.Value.GetHashCode() : 0)*397) ^ equal.GetHashCode();
            }
        }

        #endregion
    }
}
