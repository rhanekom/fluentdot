/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// An attribute that sets whether the edge label may appear on top of other edges.
    /// </summary>
    public class LabelFloatAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelFloatAttribute"/> class.
        /// </summary>
        /// <param name="shouldFloat">if set to <c>true</c> [should float].</param>
        public LabelFloatAttribute(bool shouldFloat) : base("labelfloat", new BooleanValue(shouldFloat), true)
        {
            
        }

        #endregion
    }
}