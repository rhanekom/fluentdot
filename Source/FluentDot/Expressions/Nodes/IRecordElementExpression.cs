/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// An expression for configuring a single record element.
    /// </summary>
    public interface IRecordElementExpression {

        /// <summary>
        /// Sets the label on the record element.
        /// </summary>
        /// <param name="label">The label to set on the record element.</param>
        /// <returns>The current expression instance.</returns>
        IRecordElementExpression WithLabel(string label);

        /// <summary>
        /// Sets this instance as inverted.   When inverted, the record element box will be drawn in the opposite orientation than the group orientation.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IRecordElementExpression IsInverted();
    }
}