/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute for setting the cluster rank mode.
    /// </summary>
    public class ClusterRankAttribute : AbstractDotAttribute {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterRankAttribute"/> class.
        /// </summary>
        /// <param name="clusterMode">The cluster mode.</param>
        public ClusterRankAttribute(ClusterMode clusterMode) : base("clusterrank", clusterMode, true)
        {
         
        }

        #endregion
    }
}
