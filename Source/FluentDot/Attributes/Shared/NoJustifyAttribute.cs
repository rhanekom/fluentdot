/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute that sets justification on or off in the global context of a node, graph, or edge multiline label.
    /// </summary>
    public class NoJustifyAttribute : AbstractDotAttribute<BooleanValue>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NoJustifyAttribute"/> class.
        /// </summary>
        /// <param name="value">if set to <c>true</c> then disable justification in the global context.</param>
        /// <exception cref="ArgumentOutOfRangeException">When rank is less than 0.</exception>
        public NoJustifyAttribute(bool value)
            : base("nojustify", new BooleanValue(value), true)
        {
            
        }

        #endregion
    }
}