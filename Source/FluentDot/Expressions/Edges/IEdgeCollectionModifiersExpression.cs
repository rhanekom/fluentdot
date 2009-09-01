/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// An expression for modifying a collection of edges.
    /// </summary>
    public interface IEdgeCollectionModifiersExpression<T> {

        /// <summary>
        /// Adds nodes configured by the specified add expression.
        /// </summary>
        /// <param name="addExpression">The add expression.</param>
        /// <returns>The parent expression instance.</returns>
        T Add(Action<IEdgeCollectionAddExpression> addExpression);
    }
}