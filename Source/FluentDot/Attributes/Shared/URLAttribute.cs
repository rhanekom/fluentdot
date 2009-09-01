/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// A attribute for specifying the url of an element.
    /// </summary>
    public class URLAttribute : AbstractDotAttribute {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="URLAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public URLAttribute(string value) : base("URL", value, true)
        {
            
        }

        #endregion
    }
}