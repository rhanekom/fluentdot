/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// Styles that can be applied to edges.
    /// </summary>
    public class EdgeStyle : StringEnum, IDotElement {

        #region Constants

        /// <summary>
        /// Dashed edge style.
        /// </summary>
        public static readonly EdgeStyle Dashed = new EdgeStyle("dashed");

        /// <summary>
        /// Dotted edge style.
        /// </summary>
        public static readonly EdgeStyle Dotted = new EdgeStyle("dotted");

        /// <summary>
        /// Solid edge style.
        /// </summary>
        public static readonly EdgeStyle Solid = new EdgeStyle("solid");

        /// <summary>
        /// Causes the edge to become invisible.  Invisible edges still affect layout.
        /// </summary>
        public static readonly EdgeStyle Invisible = new EdgeStyle("invis");

        /// <summary>
        /// Bold edge style.
        /// </summary>
        public static readonly EdgeStyle Bold = new EdgeStyle("bold");
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeStyle"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public EdgeStyle(string value)
            : base(value)
        {

        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            return Value;
        }

        #endregion
    }
}