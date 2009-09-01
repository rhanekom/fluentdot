/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An implementation of the label attribute.
    /// </summary>
    public class LabelAttribute : AbstractDotAttribute {

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public LabelAttribute(string value) : base("label", value, true)
        {
            // Nothing to do.
        }
    }
}