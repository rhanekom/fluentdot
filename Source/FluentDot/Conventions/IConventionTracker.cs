/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;

namespace FluentDot.Conventions
{
    /// <summary>
    /// A tracker and applier of conventions.
    /// </summary>
    public interface IConventionTracker
    {
        /// <summary>
        /// Adds the specified convention to the tracker.
        /// </summary>
        /// <param name="convention">The convention to add to this instance.</param>
        void AddConvention(IEdgeConvention convention);

        /// <summary>
        /// Adds the specified convention to the tracker.
        /// </summary>
        /// <param name="convention">The convention to add to this instance.</param>
        void AddConvention(INodeConvention convention);
        
        /// <summary>
        /// Applies the known conventions to the specified node.
        /// </summary>
        /// <param name="node">The node to apply the conventions to.</param>
        void ApplyConventions(IGraphNode node);

        /// <summary>
        /// Applies the known conventions to the specified edge.
        /// </summary>
        /// <param name="edge">The edge to apply the conventions to.</param>
        void ApplyConventions(IEdge edge);
    }
}
