/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// A concrete implementation of a <see cref="IDirectedGraph"/>.
    /// </summary>
    public class DirectedGraph : AbstractGraph, IDirectedGraph {

        #region AbstractGraph Members

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public override GraphType Type
        {
            get { return GraphType.Directed; }
        }

        /// <summary>
        /// Gets the graph indicator.
        /// </summary>
        /// <value>The graph indicator.</value>
        protected override string GraphIndicator {
            get { return "digraph"; }
        }
       
        #endregion
    }
}