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
    /// An attribute that sets the label distance on an edge.
    /// </summary>
    public class LabelDistanceAttribute : AbstractDotAttribute<double>
    {
        #region Globals

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelDistanceAttribute"/> class.
        /// </summary>
        /// <param name="distance">The distance.</param>
        public LabelDistanceAttribute(double distance) : base("labeldistance", distance, false)
        {
            if (distance < 0)
            {
                throw new ArgumentOutOfRangeException("distance", "Label distance can not be smaller than 0.");
            }
        }

        #endregion
    }
}