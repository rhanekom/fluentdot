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
    /// A concrete implementation of a <see cref="IMultiActionExpression{TValue, TReturn}"/>
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    /// <typeparam name="TReturn">The type of the return value.</typeparam>
    public class MultiActionExpression<TValue, TReturn> : IMultiActionExpression<TValue, TReturn> {

        #region Globals

        private readonly TValue target;
        private readonly TReturn returnValue;
        private readonly Action<TValue> postAction;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiActionExpression{TValue, TReturn}"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="returnValue">The return value.</param>
        public MultiActionExpression(TValue target, TReturn returnValue) : this(target, returnValue, null)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiActionExpression{TValue, TReturn}"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="returnValue">The return value.</param>
        /// <param name="postAction">The post action.</param>
        public MultiActionExpression(TValue target, TReturn returnValue, Action<TValue> postAction) {
            this.target = target;
            this.returnValue = returnValue;
            this.postAction = postAction;
        }

        #endregion

        #region IMultiActionExpression<TValue> Members

        /// <summary>
        /// Sets the specified parameter value.
        /// </summary>
        /// <param name="value">The value.</param>
        public TReturn Are(Action<TValue> value) {

            if (value != null)
            {
                value(target);

                if (postAction != null)
                {
                    postAction(target);
                }
            }

            return returnValue;
        }

        #endregion
    }
}