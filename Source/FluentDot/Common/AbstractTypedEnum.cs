/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Common
{
    /// <summary>
    /// A base class for all concrete implementations of a <see cref="ITypedEnum{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AbstractTypedEnum<T> : ITypedEnum<T> {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractTypedEnum&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public AbstractTypedEnum(T value)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException("value");
            }

            Value = value;
        }

        #endregion

        #region ITypedEnum<T> Members

        /// <summary>
        /// Gets the value that this instance represents.
        /// </summary>
        /// <value>The value.</value>
        public T Value {
            get;
            private set;
        }

        #endregion

        #region Object Members

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj)
        {
            var other = obj as AbstractTypedEnum<T>;
            return other != null && Equals(Value, other.Value);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        #endregion
    }
}