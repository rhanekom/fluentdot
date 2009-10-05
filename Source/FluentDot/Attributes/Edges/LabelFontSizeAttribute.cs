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
    /// An attribute that specifies the font size of the head and tail label on edges.
    /// </summary>
    public class LabelFontSizeAttribute : AbstractDotAttribute<double> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelFontSizeAttribute"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public LabelFontSizeAttribute(double points)
            : base("labelfontsize", points, false) {
            if (points < 1.0) {
                throw new ArgumentOutOfRangeException("points", "Label font size can not be smaller than 1 point.");
            }
            }

        #endregion
    }
}