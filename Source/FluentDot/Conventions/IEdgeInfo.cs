/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Conventions
{
    /// <summary>
    /// Provides read-only information on an edge.
    /// </summary>
    public interface IEdgeInfo
    {
        /// <summary>
        /// Gets the node that this edge originates from.
        /// </summary>
        /// <value>The from node.</value>
        INodeInfo FromNode { get; }

        /// <summary>
        /// Gets the node that this edge is directed to.
        /// </summary>
        /// <value>The to node.</value>
        INodeInfo ToNode { get; }

        /// <summary>
        /// Gets the tag associated with this edge.
        /// </summary>
        /// <value>The tag associated with this edge.</value>
        object Tag { get; }
    }
}
