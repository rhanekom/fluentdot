/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Edges {

    /// <summary>
    /// An attribute that specifies that whether the edge tail should be clip at the node boundary.
    /// </summary>
    public class TailClipAttribute : AbstractDotAttribute<BooleanValue> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="TailClipAttribute"/> class.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then clip the tail of the edge.</param>
        public TailClipAttribute(bool value)
            : base("tailclip", new BooleanValue(value), true) {

        }

        #endregion
    }
}
