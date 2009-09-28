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

        /// <summary>
        /// A dashed node style.
        /// </summary>
        public static readonly NodeStyle Dashed = new NodeStyle("dashed");

        /// <summary>
        /// A dotted node style.
        /// </summary>
        public static readonly NodeStyle Dotted = new NodeStyle("dotted");

        /// <summary>
        /// A solid node style.
        /// </summary>
        public static readonly NodeStyle Solid = new NodeStyle("solid");

        /// <summary>
        /// Removes the node border.
        /// </summary>
        public static readonly NodeStyle Invisible = new NodeStyle("invis");

        /// <summary>
        /// A bold node style.
        /// </summary>
        public static readonly NodeStyle Bold = new NodeStyle("bold");

        /// <summary>
        /// A filled node style.
        /// </summary>
        public static readonly NodeStyle Filled = new NodeStyle("filled");

        /// <summary>
        /// Diagonals node style.
        /// </summary>
        public static readonly NodeStyle Diagonals = new NodeStyle("diagonals");

        /// <summary>
        /// Rounded node style.
        /// </summary>
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