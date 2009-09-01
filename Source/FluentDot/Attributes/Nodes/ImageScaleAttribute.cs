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
    /// An attribute that sets whether an image should be scaled to fit the node size.
    /// </summary>
    public class ImageScaleAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageScaleAttribute"/> class.
        /// </summary>
        /// <param name="scale">if set to <c>true</c> scale the image.</param>
        public ImageScaleAttribute(bool scale)
            : base("imagescale", new BooleanValue(scale), false) {

            }

        #endregion
    }
}