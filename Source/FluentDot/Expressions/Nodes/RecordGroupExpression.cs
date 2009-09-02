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
    /// A concrete implementation of an <see cref="IRecordGroupExpression"/>.
    /// </summary>
    public class RecordGroupExpression : IRecordGroupExpression {
        
        #region Globals

        private readonly RecordGroup group;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordGroupExpression"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        public RecordGroupExpression(RecordGroup group)
        {
            this.group = group;
        }

        #endregion

        #region IRecordGroupExpression Members

        /// <summary>
        /// Sets this instance as inverted.   When inverted, the record element box will be drawn in the opposite orientation than the group orientation.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IRecordGroupExpression IsInverted() {
            group.IsInverted = true;
            return this;
        }

        #endregion
    }
}