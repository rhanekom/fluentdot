/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges {

    /// <summary>
    /// An attribute that sets the logical head of an edge.  When compound is true, if the logical head is defined and is 
    /// the name of a cluster containing the real head, the edge is clipped to the boundary of the cluster.
    /// </summary>
    public class LogicalHeadAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicalHeadAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public LogicalHeadAttribute(string name)
            : base("lhead", name, true)
        {
            
        }

        #endregion
    }
}
