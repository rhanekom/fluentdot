/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges {
    
    /// <summary>
    /// Edges with the same head and the same samehead value are aimed at the same point on the head.
    /// </summary>
    public class SameHeadAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="SameHeadAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public SameHeadAttribute(string value) : base("samehead", value, true) {
        
        }

        #endregion
    }
}