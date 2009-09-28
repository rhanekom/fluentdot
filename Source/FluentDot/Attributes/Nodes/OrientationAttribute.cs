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
    /// An attribute for defining the orientation of a node.
    /// </summary>
    public class OrientationAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OrientationAttribute"/> class.
        /// </summary>
        /// <param name="degrees">The degrees.</param>
        public OrientationAttribute(int degrees) : base("orientation", degrees, false)
        {
            if ((degrees < 0) || (degrees > 360))
            {
                throw new ArgumentOutOfRangeException("degrees", "Node orientation degrees must be between 0 and 360 degrees inclusive.");
            }
        }

        #endregion
    }
}