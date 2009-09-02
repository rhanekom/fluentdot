/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using FluentDot.Entities.Graphs;

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// A concrete implementation of a <see cref="INodeTracker"/>.
    /// </summary>
    public class NodeTracker : INodeTracker {
       
        #region Globals

        private readonly Dictionary<object, IGraphNode> nodesByTag = new Dictionary<object, IGraphNode>();
        private readonly Dictionary<string, IGraphNode> nodesByName = new Dictionary<string, IGraphNode>();
        
        #endregion

        #region INodeTracker Members

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        /// <value>The nodes.</value>
        public IEnumerable<IGraphNode> Nodes {
            get { return nodesByName.Values; }
        }

        /// <summary>
        /// Adds the node to the tracker.
        /// </summary>
        /// <param name="node">The node to add.</param>
        public void AddNode(IGraphNode node) {
            nodesByName.Add(node.Name, node);

            if (node.Tag != null)
            {
                nodesByTag.Add(node.Tag, node);
            }
        }

        /// <summary>
        /// Gets the node by name.
        /// </summary>
        /// <param name="name">The name of the node.</param>
        /// <returns>A node that has the specified name.</returns>
        public IGraphNode GetNodeByName(string name) {
            IGraphNode node;
            return nodesByName.TryGetValue(name, out node) ? node : null;
        }

        /// <summary>
        /// Gets the node by tag.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag attached to the node.</param>
        /// <returns>A node that has the specified tag.</returns>
        public IGraphNode GetNodeByTag<T>(T tag) {
            IGraphNode node;
            return nodesByTag.TryGetValue(tag, out node) ? node : null;
        }

        #endregion
    }
}