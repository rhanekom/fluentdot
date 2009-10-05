/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute for setting the background color of a graph.
    /// </summary>
    public class BackgroundColorAttribute : AbstractDotAttribute<ColorValue> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="BackgroundColorAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public BackgroundColorAttribute(Color value)
            : base("bgcolor", new ColorValue(value), true)
        {
            // Nothing to do.
        }

        #endregion
    }
}