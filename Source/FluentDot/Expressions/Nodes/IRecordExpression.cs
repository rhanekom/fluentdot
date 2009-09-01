/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// An expression for constructing record nodes.
    /// </summary>
    public interface IRecordExpression {

        /// <summary>
        /// Adds an element to the group with the specified name;
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The current expression instance.</returns>
        IRecordExpression WithElement(string name);

        /// <summary>
        /// Adds an element to the group with the specified name and label.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="elementConfiguration">The element configuration.</param>
        /// <returns>The current expression instance.</returns>
        IRecordExpression WithElement(string name, Action<IRecordElementExpression> elementConfiguration);

        /// <summary>
        /// Adds a group to this record.
        /// </summary>
        /// <param name="groupContentConfiguration">The group content configuration.</param>
        /// <returns>The current expression instance.</returns>
        IRecordExpression WithGroup(Action<IRecordExpression> groupContentConfiguration);

        /// <summary>
        /// Adds a group to this record.
        /// </summary>
        /// <param name="groupContentConfiguration">The group content configuration.</param>
        /// <param name="groupConfiguration">The group configuration.</param>
        /// <returns>The current expression instance.</returns>
        IRecordExpression WithGroup(Action<IRecordExpression> groupContentConfiguration, Action<IRecordGroupExpression> groupConfiguration);
    }
}