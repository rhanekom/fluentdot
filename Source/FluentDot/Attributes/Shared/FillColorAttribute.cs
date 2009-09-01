/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute that specifies the fill color of a node or cluster graph.
    /// </summary>
    public class FillColorAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="FillColorAttribute"/> class.
        /// </summary>
        /// <param name="fillColor">Color of the fill.</param>
        public FillColorAttribute(Color fillColor)
            : base("fillcolor", new ColorValue(fillColor), true)
        {

        }

        #endregion
    }
}