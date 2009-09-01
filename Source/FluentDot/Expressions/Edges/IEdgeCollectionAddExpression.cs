/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// An expression that adds an edge to an edge collection.
    /// </summary>
    public interface IEdgeCollectionAddExpression {

        /// <summary>
        /// Specifies where the edge should be emanating from.
        /// </summary>
        /// <value>An expression to specify where the edge should be emanating from.</value>
        IEdgeSourceExpression From { get; }
    }
}