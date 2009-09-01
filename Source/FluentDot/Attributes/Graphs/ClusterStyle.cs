/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// Styles that can be applied to edges.
    /// </summary>
    public class ClusterStyle : StringEnum, IDotElement {

        #region Constants
        
        public static readonly ClusterStyle Filled = new ClusterStyle("filled");
        public static readonly ClusterStyle Rounded = new ClusterStyle("rounded");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterStyle"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public ClusterStyle(string value)
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