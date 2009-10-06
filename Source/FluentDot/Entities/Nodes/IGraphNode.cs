/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// A single instance of a node in a graph.
    /// </summary>
    public interface IGraphNode : IDotElement, IAttributeBasedEntity {

        /// <summary>
        /// Gets or sets the name of the node.
        /// </summary>
        /// <value>The name of the node.</value>
        string Name { get; }

        /// <summary>
        /// Gets or sets the tag attached to the node.
        /// </summary>
        /// <value>The tag on the node.</value>
        object Tag { get; set; }
    }
}