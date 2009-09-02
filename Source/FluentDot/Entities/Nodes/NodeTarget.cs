/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// A concrete implementation of a <see cref="INodeTarget"/>.
    /// </summary>
    public class NodeTarget : INodeTarget {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeTarget"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public NodeTarget(IGraphNode node) {
            Node = node;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeTarget"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="elementName">Name of the element.</param>
        public NodeTarget(IRecordNode node, string elementName) {
            Node = node;
            ElementName = elementName;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        public IGraphNode Node { get; private set; }

        /// <summary>
        /// Gets or sets the name of the element.
        /// </summary>
        /// <value>The name of the element.</value>
        public string ElementName { get; set; }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            return ElementName == null 
                       ? string.Format("\"{0}\"", Node.Name )
                       : string.Format("\"{0}\":\"{1}\"", Node.Name, ElementName);
        }

        #endregion
    }
}