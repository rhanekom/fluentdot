/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;
using FluentDot.Entities.Nodes;

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// A representation of an edge, that is, a connecting component between to <see cref="IGraphNode"/>s.
    /// </summary>
    public interface IEdge : IDotElement, IAttributeBasedEntity {

        /// <summary>
        /// Gets the node this edge is emanating from.
        /// </summary>
        /// <value>The from node.</value>
        INodeTarget From { get; }

        /// <summary>
        /// Gets the node this edge is going to.
        /// </summary>
        /// <value>The to node.</value>
        INodeTarget To { get; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag of the edge.</value>
        object Tag { get; set; }
    }
}