/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Nodes;

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// An instance of a directed edge.
    /// </summary>
    public class DirectedEdge : AbstractEdge {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectedEdge"/> class.
        /// </summary>
        /// <param name="fromNode">The from node.</param>
        /// <param name="toNode">The to node.</param>
        public DirectedEdge(INodeTarget fromNode, INodeTarget toNode)
            : base(fromNode, toNode)
        {
            // Nothing to do.
        }

        #endregion

        #region AbstractEdge Members

        /// <summary>
        /// Gets the edge indicator.
        /// </summary>
        /// <value>The edge indicator.</value>
        protected override string EdgeIndicator {
            get { return "->"; }
        }

        #endregion
    }
}