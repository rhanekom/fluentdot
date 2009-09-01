/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Shared {

    /// <summary>
    /// An expression that performs multiple actions on the specified parameter.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <typeparam name="TReturn">The type of the return value.</typeparam>
    public interface IMultiActionExpression<TValue, TReturn> {

        /// <summary>
        /// Sets the specified parameter value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The parent expression instance.</returns>
        TReturn Are(Action<TValue> value);
    }
}