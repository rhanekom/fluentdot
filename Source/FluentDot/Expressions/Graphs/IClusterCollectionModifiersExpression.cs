/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// An expression for modifying a node collection.
    /// </summary>
    /// <typeparam name="T">The type of parent expression.</typeparam>
    public interface IClusterCollectionModifiersExpression<T> {

        /// <summary>
        /// Adds clusters to the graph.
        /// </summary>
        /// <param name="addExpression">The add expression to modify.</param>
        /// <returns>The parent expression instance.</returns>
        T Add(Action<IClusterCollectionAddExpression> addExpression);
    }
}