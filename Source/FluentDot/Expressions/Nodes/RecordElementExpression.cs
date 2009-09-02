/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Nodes;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// A concrete implementation of a <see cref="IRecordElementExpression"/>.
    /// </summary>
    public class RecordElementExpression : IRecordElementExpression {
        
        #region Globals

        private readonly RecordElement recordElement;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordElementExpression"/> class.
        /// </summary>
        /// <param name="recordElement">The record element.</param>
        public RecordElementExpression(RecordElement recordElement)
        {
            this.recordElement = recordElement;
        }

        #endregion

        #region IRecordElementExpression Members

        /// <summary>
        /// Sets the label on the record element.
        /// </summary>
        /// <param name="label">The label to set on the record element.</param>
        /// <returns>The current expression instance.</returns>
        public IRecordElementExpression WithLabel(string label) {
            recordElement.Label = label;
            return this;
        }

        /// <summary>
        /// Sets this instance as inverted.   When inverted, the record element box will be drawn in the opposite orientation than the group orientation.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IRecordElementExpression IsInverted() {
            recordElement.IsInverted = true;
            return this;
        }

        #endregion
    }
}