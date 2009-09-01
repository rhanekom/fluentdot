/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// An instance of an undirected edge.
    /// </summary>
    public class UndirectedEdge : AbstractEdge {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="UndirectedEdge"/> class.
        /// </summary>
        /// <param name="fromNode">The from node.</param>
        /// <param name="toNode">The to node.</param>
        public UndirectedEdge(INodeTarget fromNode, INodeTarget toNode)
            : base(fromNode, toNode) {
            // Nothing to do.
            }

        #endregion

        #region AbstractEdge Members

        /// <summary>
        /// Gets the edge indicator.
        /// </summary>
        /// <value>The edge indicator.</value>
        protected override string EdgeIndicator {
            get { return "--"; }
        }

        #endregion
    }
}