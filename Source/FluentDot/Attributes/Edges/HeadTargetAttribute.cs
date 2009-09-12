/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges {
    
    /// <summary>
    /// An attribute that sets the target on an edge head.
    /// </summary>
    public class HeadTargetAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="HeadTargetAttribute"/> class.
        /// </summary>
        /// <param name="target">The target.</param>
        public HeadTargetAttribute(string target)
            : base("headtarget", target, true) {

        }

        #endregion
    }
}
