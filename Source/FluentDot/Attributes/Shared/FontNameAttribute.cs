﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute for setting the font name of nodes, graphs, and edges.
    /// </summary>
    public class FontNameAttribute : AbstractDotAttribute<string> {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="FontNameAttribute"/> class.
        /// </summary>
        /// <param name="fontName">Name of the font.</param>
        public FontNameAttribute(string fontName)
            : base("fontname", fontName, true) {

            }

        #endregion
    }
}