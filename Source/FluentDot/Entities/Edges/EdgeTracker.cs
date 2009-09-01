/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// A concrete implementation of a <see cref="IEdgeTracker"/>.
    /// </summary>
    public class EdgeTracker : IEdgeTracker {
        
        #region Globals

        private readonly List<IEdge> edges = new List<IEdge>();
        private readonly Dictionary<object, IEdge> edgesByTag = new Dictionary<object, IEdge>();

        #endregion

        #region IEdgeTracker Members

        /// <summary>
        /// Gets the edges.
        /// </summary>
        /// <value>The edges.</value>
        public IEnumerable<IEdge> Edges {
            get { return new ReadOnlyCollection<IEdge>( edges); }
        }

        /// <summary>
        /// Adds the edge to the collection of edges.
        /// </summary>
        /// <param name="edge">The edge to add to the collection.</param>
        public void AddEdge(IEdge edge) {
            edges.Add(edge);

            if (edge.Tag != null)
            {
                edgesByTag.Add(edge.Tag, edge);
            }
        }

        /// <summary>
        /// Gets the node by tag.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag attached to the edge.</param>
        /// <returns>An edge that has the specified tag.</returns>
        public IEdge GetEdgeByTag<T>(T tag)
        {
            IEdge edge;
            return edgesByTag.TryGetValue(tag, out edge) ? edge : null;
        }

        #endregion
    }
}