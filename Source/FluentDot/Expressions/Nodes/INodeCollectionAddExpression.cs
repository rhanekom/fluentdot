/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// An expression for adding nodes in a graph.
    /// </summary>
    public interface INodeCollectionAddExpression {

        /// <summary>
        /// Adds a node with the specified name to the graph.
        /// </summary>
        /// <param name="name">The name of the node to create.</param>
        /// <returns>A node expression for configuring the node.</returns>
        INodeExpression WithName(string name);
    }
}