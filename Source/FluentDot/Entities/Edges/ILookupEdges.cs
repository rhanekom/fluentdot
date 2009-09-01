/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// An interface for a class that can lookup edges.
    /// </summary>
    public interface ILookupEdges {

        /// <summary>
        /// Gets the node by tag.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag attached to the edge.</param>
        /// <returns>An edge that has the specified tag.</returns>
        IEdge GetEdgeByTag<T>(T tag);
    }
}