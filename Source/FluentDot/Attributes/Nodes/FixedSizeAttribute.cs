/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Nodes
{
    /// <summary>
    /// An attribute for setting the node sizing mode as fixed size.  If this is set, the node will not expand to contain the label.
    /// </summary>
    public class FixedSizeAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="FixedSizeAttribute"/> class.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public FixedSizeAttribute(bool value) : base("fixedsize", new BooleanValue(value), false)
        {
            
        }

        #endregion
    }
}