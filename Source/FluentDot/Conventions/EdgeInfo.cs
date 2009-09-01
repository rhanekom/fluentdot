/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Edges;

namespace FluentDot.Conventions
{
    /// <summary>
    /// A concrete implementation of an <see cref="IEdgeInfo"/>.
    /// </summary>
    public class EdgeInfo : IEdgeInfo
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeInfo"/> class.
        /// </summary>
        /// <param name="edge">The edge.</param>
        public EdgeInfo(IEdge edge) : this(new NodeInfo(edge.From.Node), new NodeInfo(edge.To.Node), edge.Tag)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeInfo"/> class.
        /// </summary>
        /// <param name="fromNode">From node.</param>
        /// <param name="toNode">To node.</param>
        /// <param name="tag">The tag.</param>
        public EdgeInfo(INodeInfo fromNode, INodeInfo toNode, object tag)
        {
            FromNode = fromNode;
            ToNode = toNode;
            Tag = tag;
        }

        #endregion

        #region IEdgeInfo Members

        /// <summary>
        /// Gets the node that this edge originates from.
        /// </summary>
        /// <value>The from node.</value>
        public INodeInfo FromNode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the node that this edge is directed to.
        /// </summary>
        /// <value>The to node.</value>
        public INodeInfo ToNode
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the tag associated with this edge.
        /// </summary>
        /// <value>The tag associated with this edge.</value>
        public object Tag
        {
            get; private set;
        }

        #endregion
    }
}