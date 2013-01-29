﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// An expression for modifying a node collection.
    /// </summary>
    public interface INodeCollectionModifiersExpression<T> {

        /// <summary>
        /// Adds nodes to the graph.
        /// </summary>
        /// <param name="addExpression">The add expression to modify.</param>
        /// <returns>The parent expression instance.</returns>
        T Add(Action<INodeCollectionAddExpression> addExpression);

        /// <summary>
        /// Adds record nodes to the graph.
        /// </summary>
        /// <param name="addExpression">The add expression to modify.</param>
        /// <returns>The parent expression instance.</returns>
        T AddRecord(Action<IRecordCollectionAddExpression> addExpression);
    }
}