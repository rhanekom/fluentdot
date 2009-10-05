/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that rotates the rendering of a graph.
    /// </summary>
    public class RotateAttribute : AbstractDotAttribute<double> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RotateAttribute"/> class.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        public RotateAttribute(double degrees)
            : base("rotate", degrees, false)
        {
            if (degrees < 0)
            {
                throw new ArgumentOutOfRangeException("degrees", "Degrees for rotation can not be less than 0.");
            }
        }

        #endregion
    }
}