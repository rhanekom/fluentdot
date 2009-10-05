/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that specifies where a label should be located horizontally.
    /// </summary>
    public class LabelJustificationAttribute : AbstractDotAttribute<Justification> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelJustificationAttribute"/> class.
        /// </summary>
        /// <param name="justification">The justification.</param>
        public LabelJustificationAttribute(Justification justification)
            : base("labeljust", justification, true) {

            }

        #endregion
    }
}