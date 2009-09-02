/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;
using FluentDot.Entities.Graphs;

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// A class that keeps track of node selected.
    /// </summary>
    public interface INodeTarget : IDotElement
    {
        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        IGraphNode Node { get; }

        /// <summary>
        /// Gets or sets the name of the element.
        /// </summary>
        /// <value>The name of the element.</value>
        string ElementName { get; }
    }
}