/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that sets the style on a node or edge.
    /// </summary>
    public class ClusterStyleAttribute : AbstractDotAttribute<ClusterStyle>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterStyleAttribute"/> class.
        /// </summary>
        /// <param name="style">The style.</param>
        public ClusterStyleAttribute(ClusterStyle style)
            : base("style", style, true) {

            }

        #endregion
    }
}