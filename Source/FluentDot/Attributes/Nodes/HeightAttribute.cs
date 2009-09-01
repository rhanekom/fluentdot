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
    /// An attribute that sets the height on a node.
    /// </summary>
    public class HeightAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="HeightAttribute"/> class.
        /// </summary>
        /// <param name="height">The height.</param>
        public HeightAttribute(double height) : base("height", height, false)
        {
            if (height < 0.02)
            {
                throw new ArgumentOutOfRangeException("height", "Height can not be smaller than 0.01.");
            }
        }

        #endregion
    }
}