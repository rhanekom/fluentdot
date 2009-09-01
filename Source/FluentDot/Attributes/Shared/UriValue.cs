/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Common;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// A value specified as an Uri.
    /// </summary>
    public class UriValue : IDotElement {
       
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="UriValue"/> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        public UriValue(Uri uri) {
            Value = uri;
        }

        #endregion
       
        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            return Value.ToString();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public Uri Value {get; private set;}

        #endregion
    }
}