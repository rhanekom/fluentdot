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
    /// An attribute that sets the width on a node.
    /// </summary>
    public class WidthAttribute : AbstractDotAttribute<double>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="WidthAttribute"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        public WidthAttribute(double width) : base("width", width, false)
        {
            if (width < 0.01)
            {
                throw new ArgumentOutOfRangeException("width", "Width cannot be smaller than 0.01.");
            }
        }

        #endregion
    }
}