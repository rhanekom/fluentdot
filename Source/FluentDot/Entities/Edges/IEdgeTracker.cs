/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// Provides tracking for edges.
    /// </summary>
    public interface IEdgeTracker : ILookupEdges {

        /// <summary>
        /// Gets the edges.
        /// </summary>
        /// <value>The edges.</value>
        IEnumerable<IEdge> Edges { get; }

        /// <summary>
        /// Adds the edge to the collection of edges.
        /// </summary>
        /// <param name="edge">The edge to add to the collection.</param>
        void AddEdge(IEdge edge);
    }
}