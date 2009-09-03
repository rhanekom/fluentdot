/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute that sets the pen color of a cluster.
    /// </summary>
    public class PenColorAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PenColorAttribute"/> class.
        /// </summary>
        /// <param name="color">The color.</param>
        public PenColorAttribute(Color color)
            : base("pencolor", new ColorValue(color), true)
        {

        }

        #endregion
    }
}
