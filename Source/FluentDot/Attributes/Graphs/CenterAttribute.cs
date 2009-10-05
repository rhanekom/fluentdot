/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute for centering the graph on the canvas.
    /// </summary>
    public class CenterAttribute : AbstractDotAttribute<BooleanValue> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CenterAttribute"/> class.
        /// </summary>
        /// <param name="centered">if set to <c>true</c> [centered].</param>
        public CenterAttribute(bool centered)
            : base("center", new BooleanValue(centered), true)
        {

        }

        #endregion
    }
}