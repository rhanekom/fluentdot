/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute that, when set, specifies the width and height of the pages the graph should be split in.
    /// This attribute is currently only supported by PostScript. 
    /// </summary>
    public class PageAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PageAttribute"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public PageAttribute(float x, float y) : base("page", new PointValue(x, y), true) {

        }

        #endregion
    }
}
