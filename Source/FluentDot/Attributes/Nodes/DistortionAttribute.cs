/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Nodes
{
    /// <summary>
    /// An attribute that changes the distortion vaue of a node shape (polygons only).
    /// </summary>
    public class DistortionAttribute : AbstractDotAttribute<double>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="DistortionAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public DistortionAttribute(double value) : base("distortion", value, false)
        {
            if ((value < -100) || (value > 100))
            {
                throw new ArgumentOutOfRangeException("value","Distortion value must fall in the range -100.0 to 100.0.");
            }
        }

        #endregion
    }
}
