/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges {
    
    /// <summary>
    /// An attribute that sets the url on an edge head.
    /// </summary>
    public class HeadURLAttribute : AbstractDotAttribute<string> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="HeadURLAttribute"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public HeadURLAttribute(string url)
            : base("headURL", url, true) {

        }

        #endregion
    }
}
