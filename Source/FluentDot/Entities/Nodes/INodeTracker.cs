/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// An object that keeps track of nodes added to a graph.
    /// </summary>
    public interface INodeTracker : ILookupNodes {

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>The nodes.</value>
        IEnumerable<IGraphNode> Nodes { get; }

        /// <summary>
        /// Adds the node to the tracker.
        /// </summary>
        /// <param name="node">The node to add.</param>
        void AddNode(IGraphNode node);
    }
}