/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// An attribute for setting the font name of the head and tail label on edges.
    /// </summary>
    public class LabelFontNameAttribute : AbstractDotAttribute<string> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelFontNameAttribute"/> class.
        /// </summary>
        /// <param name="fontName">Name of the font.</param>
        public LabelFontNameAttribute(string fontName)
            : base("labelfontname", fontName, true) {

            }

        #endregion
    }
}