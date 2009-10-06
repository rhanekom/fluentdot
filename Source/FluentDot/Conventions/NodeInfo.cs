/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Nodes;

namespace FluentDot.Conventions
{
    /// <summary>
    /// A concrete implementation of an <see cref="INodeInfo"/>.
    /// </summary>
    public class NodeInfo : INodeInfo
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeInfo"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public NodeInfo(IGraphNode node) : this(node.Name, node.Tag)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeInfo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
        public NodeInfo(string name, object tag)
        {
            Name = name;
            Tag = tag;
        }

        #endregion

        #region INodeInfo Members

        /// <summary>
        /// Gets the name of the node.
        /// </summary>
        /// <value>The name of the node.</value>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the tag attached to the node.
        /// </summary>
        /// <value>The tag attached to the node.</value>
        public object Tag
        {
            get;
            private set;
        }

        #endregion
    }
}