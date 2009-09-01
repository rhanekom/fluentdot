/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Nodes
{
    /// <summary>
    /// Styles that can be applied to edges.
    /// </summary>
    public class NodeStyle : StringEnum, IDotElement {

        #region Constants

        public static readonly NodeStyle Dashed = new NodeStyle("dashed");
        public static readonly NodeStyle Dotted = new NodeStyle("dotted");
        public static readonly NodeStyle Solid = new NodeStyle("solid");
        public static readonly NodeStyle Invisible = new NodeStyle("invis");
        public static readonly NodeStyle Bold = new NodeStyle("bold");
        public static readonly NodeStyle Filled = new NodeStyle("filled");
        public static readonly NodeStyle Diagonals = new NodeStyle("diagonals");
        public static readonly NodeStyle Rounded = new NodeStyle("rounded");
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeStyle"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public NodeStyle(string value)
            : base(value) {

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