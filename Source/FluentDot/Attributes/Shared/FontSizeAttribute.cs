/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute that specifies the font size used in nodes, graphs, and edges.
    /// </summary>
    public class FontSizeAttribute : AbstractDotAttribute<double> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="FontSizeAttribute"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public FontSizeAttribute(double points) : base("fontsize", points, false)
        {
            if (points < 1.0)
            {
                throw new ArgumentOutOfRangeException("points", "Font size can not be smaller than 1 point.");
            }
        }

        #endregion
    }
}