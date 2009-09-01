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
    /// An attribute to sepcify the label angle on edges.
    /// </summary>
    public class LabelAngleAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelAngleAttribute"/> class.
        /// </summary>
        /// <param name="angle">The angle.</param>
        public LabelAngleAttribute(double angle) : base("labelangle", angle, false)
        {
            if ((angle < -180) || (angle > 180))
            {
                throw new ArgumentOutOfRangeException("angle", "Angle must be in the range -180 to 180.");
            }
        }

        #endregion
    }
}