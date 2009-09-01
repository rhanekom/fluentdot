/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Common;

namespace FluentDot.Attributes
{
    /// <summary>
    /// An abstract base class for dot attributes.
    /// </summary>
    public abstract class AbstractDotAttribute : IDotAttribute {

        #region Globals
        
        private readonly bool surroundWithQuotes;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractDotAttribute"/> class.
        /// </summary>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="attributeValue">The attribute value.</param>
        /// <param name="surroundWithQuotes">if set to <c>true</c> [surround with quotes].</param>
        protected AbstractDotAttribute(string attributeName, object attributeValue, bool surroundWithQuotes)
        {
            if (string.IsNullOrEmpty(attributeName))
            {
                throw new ArgumentException("Invalid attribute name specified.", "attributeName");
            }

            if (attributeValue == null)
            {
                throw new ArgumentException("Invalid value for attribute specified.", "attributeValue");
            }

            Name = attributeName;
            Value = attributeValue;
            this.surroundWithQuotes = surroundWithQuotes;
        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public virtual string ToDot()
        {
            string format = surroundWithQuotes ? "{0}=\"{1}\"" : "{0}={1}";
            
            string dot =  string.Format(
                format, 
                Name, 
                Value is IDotElement ? ((IDotElement) Value).ToDot() : Value.ToString());

            return dot;
        }

        #endregion

        #region IDotAttribute Members

        /// <summary>
        /// Gets the attribute name.
        /// </summary>
        /// <value>The attribute name.</value>
        public string Name {
            get;
            private set;
        }

        /// <summary>
        /// Gets the attribute value.
        /// </summary>
        /// <value>The attribute value.</value>
        public object Value {
            get;
            private set;
        }

        #endregion
    }
}