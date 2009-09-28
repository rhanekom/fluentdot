/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges {

    /// <summary>
    /// An attribute that sets the logical tail of an edge.  When compound is true, if the logical tail is defined and 
    /// is the name of a cluster containing the real tail, the edge is clipped to the boundary of the cluster.
    /// </summary>
    public class LogicalTailAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LogicalTailAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public LogicalTailAttribute(string name)
            : base("ltail", name, true)
        {

        }

        #endregion
    }
}
