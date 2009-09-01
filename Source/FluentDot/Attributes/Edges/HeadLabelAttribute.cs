/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// An attribute to specify the text to be placed near the head of the edge.
    /// </summary>
    public class HeadLabelAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="HeadLabelAttribute"/> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public HeadLabelAttribute(string text) : base("headlabel", text, true)
        {
            
        }

        #endregion
    }
}