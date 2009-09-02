/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// A single instance of a node in a graph.
    /// </summary>
    public class GraphNode : AttributeBasedEntity, IGraphNode {
        
        #region Globals

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphNode"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public GraphNode(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Invalid graph node name specified", "name");
            }

            Name = name;
        }

        #endregion

        #region IGraphNode Members
        
        /// <summary>
        /// Gets or sets the name of the node.
        /// </summary>
        /// <value>The name of the node.</value>
        public string Name {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the tag attached to the node.
        /// </summary>
        /// <value>The tag on the node.</value>
        public object Tag { get; set;}

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public virtual string ToDot()
        {
            var attributes = Attributes;
            return attributes.CurrentAttributes.Count == 0 ? string.Format("\"{0}\"", Name) : string.Format("\"{0}\" {1}", Name, attributes.ToDot());
        }

        #endregion
    }
}