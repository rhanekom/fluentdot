/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using FluentDot.Entities.Graphs;

namespace FluentDot.Entities {

    /// <summary>
    /// An interface for looking up nodes.
    /// </summary>
    public interface ILookupNodes {

        /// <summary>
        /// Gets the node by name.
        /// </summary>
        /// <param name="name">The name of the node.</param>
        /// <returns>A node that has the specified name.</returns>
        IGraphNode GetNodeByName(string name);

        /// <summary>
        /// Gets the node by tag.
        /// </summary>
        /// <typeparam name="T">The type of tag.</typeparam>
        /// <param name="tag">The tag attached to the node.</param>
        /// <returns>A node that has the specified tag.</returns>
        IGraphNode GetNodeByTag<T>(T tag);
    }
}
