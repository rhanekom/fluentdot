/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// An attribute that sets the tooltip on an edge.
    /// </summary>
    public class EdgeTooltipAttribute : AbstractDotAttribute<string>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeTooltipAttribute"/> class.
        /// </summary>
        /// <param name="tooltip">The tooltip to add on the edge.</param>
        public EdgeTooltipAttribute(string tooltip)
            : base("edgetooltip", tooltip, true)
        {

        }

        #endregion
    }
}
