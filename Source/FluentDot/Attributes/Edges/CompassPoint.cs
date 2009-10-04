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
    /// Specifies the point at which an edge should be attached to the node.
    /// </summary>
    public class CompassPoint : StringEnum, IDotElement {

        #region Constants

        /// <summary>
        /// North of the node.
        /// </summary>
        public static readonly CompassPoint North = new CompassPoint("n");

        /// <summary>
        /// North-East of the node.
        /// </summary>
        public static readonly CompassPoint NorthEast = new CompassPoint("ne");

        /// <summary>
        /// East of the node.
        /// </summary>
        public static readonly CompassPoint East = new CompassPoint("e");

        /// <summary>
        /// South-East of the node.
        /// </summary>
        public static readonly CompassPoint SouthEast = new CompassPoint("se");

        /// <summary>
        /// South of the node.
        /// </summary>
        public static readonly CompassPoint South = new CompassPoint("s");

        /// <summary>
        /// South-West of the node.
        /// </summary>
        public static readonly CompassPoint SouthWest = new CompassPoint("sw");

        /// <summary>
        /// West of the node.
        /// </summary>
        public static readonly CompassPoint West = new CompassPoint("w");

        /// <summary>
        /// North-West of the node.
        /// </summary>
        public static readonly CompassPoint NorthWest = new CompassPoint("nw");

        /// <summary>
        /// Center of the node.
        /// </summary>
        public static readonly CompassPoint Center = new CompassPoint("c");

        /// <summary>
        /// The appropriate side of the port adjacent to the exterior of the node, if it exists - otherwise the center will be used.
        /// </summary>
        public static readonly CompassPoint Appropriate = new CompassPoint("_");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CompassPoint"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public CompassPoint(string value)
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
