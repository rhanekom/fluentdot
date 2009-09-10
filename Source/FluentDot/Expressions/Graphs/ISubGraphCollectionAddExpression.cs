/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// An expression for adding nodes in a graph.
    /// </summary>
    public interface ISubGraphCollectionAddExpression
    {

        /// <summary>
        /// Adds a subgraph with the specified name to the graph.
        /// </summary>
        /// <param name="name">The name of the subgraph to create.</param>
        /// <returns>A subgraph expression for configuring the graph.</returns>
        ISubGraphExpression WithName(string name);
    }
}