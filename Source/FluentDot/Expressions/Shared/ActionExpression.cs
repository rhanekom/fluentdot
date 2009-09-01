/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Shared
{
    /// <summary>
    /// A concrete implementation of a <see cref="IActionExpression{TValue}"/>.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class ActionExpression<TValue> : IActionExpression<TValue> {
        
        #region Globals

        private readonly Action<TValue> action;
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionExpression{TValue}"/> class.
        /// </summary>
        /// <param name="action">The action to execute when a value is set.</param>
        public ActionExpression(Action<TValue> action)
        {
            this.action = action;
        }

        #endregion

        #region IActionExpression<T> Members

        /// <summary>
        /// Sets the specified parameter value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Is(TValue value) {
            
            if (action != null)
            {
                action(value);
            }
        }

        #endregion
    }
}