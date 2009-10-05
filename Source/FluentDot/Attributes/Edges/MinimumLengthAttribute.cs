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
    /// An attribute that sets the minimum length of an edge (dot only).
    /// </summary>
    public class MinimumLengthAttribute : AbstractDotAttribute<int>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="MinimumLengthAttribute"/> class.
        /// </summary>
        /// <param name="rank">The rank.</param>
        /// <exception cref="ArgumentOutOfRangeException">When rank is less than 0.</exception>
        public MinimumLengthAttribute(int rank)
            : base("minlen", rank, false)
        {
            if (rank < 0)
            {
                throw new ArgumentOutOfRangeException("rank", "Rank can not be less than 0.");
            }
        }

        #endregion
    }
}