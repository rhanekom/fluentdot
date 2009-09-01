/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute that specifies where a label should be located vertically.
    /// </summary>
    public class LabelLocationAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelLocationAttribute"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        public LabelLocationAttribute(Location location) : base("labelloc", location, true)
        {

        }

        #endregion
    }
}