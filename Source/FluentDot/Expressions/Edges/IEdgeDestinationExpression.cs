/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// An expression for selecting the destination node.
    /// </summary>
    public interface IEdgeDestinationExpression {

        /// <summary>
        /// Gets an expression to select the destination node of the edge.
        /// </summary>
        /// <value>An expression to select the destination node of the edge.</value>
        IEdgeDestinationSelectionExpression To { get; }
    }
}