/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities.Nodes;

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// A concrete implementation of a <see cref="IEdge"/>.
    /// </summary>
    public abstract class AbstractEdge : AttributeBasedEntity, IEdge {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractEdge"/> class.
        /// </summary>
        /// <param name="fromNode">From node.</param>
        /// <param name="toNode">To node.</param>
        protected AbstractEdge(INodeTarget fromNode, INodeTarget toNode)
        {
            From = fromNode;
            To = toNode;
        }

        #endregion

        #region IEdge Members
        
        /// <summary>
        /// Gets the node this edge is emanating from.
        /// </summary>
        /// <value>The from node.</value>
        public INodeTarget From {
            get;
            private set;
        }

        /// <summary>
        /// Gets the node this edge is going to.
        /// </summary>
        /// <value>The to node.</value>
        public INodeTarget To {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag of the edge.</value>
        public object Tag {
            get;
            set;
        }

        #endregion

        #region Protected Members

        /// <summary>
        /// Gets the edge indicator.
        /// </summary>
        /// <value>The edge indicator.</value>
        protected abstract string EdgeIndicator { get; }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            var edgeDot = string.Format("{0} {1} {2}", From.ToDot(), EdgeIndicator, To.ToDot());
            
            var attributes = Attributes;
            return attributes.CurrentAttributes.Count == 0 ? edgeDot :
                                                                         String.Format("{0} {1}", edgeDot, attributes.ToDot());
        }

        #endregion
    }
}