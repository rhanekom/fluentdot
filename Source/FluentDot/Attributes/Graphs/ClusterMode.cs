/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// The mode dot uses for cluster layout.
    /// </summary>
    public class ClusterMode : StringEnum, IDotElement {

        #region Constants

        /// <summary>
        /// Turns off special processing for clusters.
        /// </summary>
        public static readonly ClusterMode Global = new ClusterMode("global");

        /// <summary>
        /// Clusters are given special treatment. Clusters are laid out separately, and then integrated into their parent graphs with a bounding rectangle and labels if applicable.
        /// </summary>
        public static readonly ClusterMode Local = new ClusterMode("local");

        /// <summary>
        /// Turns off special processing for clusters.
        /// </summary>
        public static readonly ClusterMode None = new ClusterMode("none");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterMode"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public ClusterMode(string value) : base(value)
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
