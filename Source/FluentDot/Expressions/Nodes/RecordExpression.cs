/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// A concrete implementation of a record expression.
    /// </summary>
    public class RecordExpression : IRecordExpression {
        
        #region Globals

        private readonly RecordGroup group;

        #endregion

        #region Globals

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordExpression"/> class.
        /// </summary>
        /// <param name="group">The group.</param>
        public RecordExpression(RecordGroup group)
        {
            this.group = group;
        }

        #endregion

        #region IRecordExpression Members

        /// <summary>
        /// Adds an element to the group with the specified name;
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The current expression instance.</returns>
        public IRecordExpression WithElement(string name) {
            return WithElement(name, null);
        }


        /// <summary>
        /// Adds an element to the group with the specified name and label.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="elementConfiguration">The element configuration.</param>
        /// <returns>The current expression instance.</returns>
        public IRecordExpression WithElement(string name, Action<IRecordElementExpression> elementConfiguration)  
        {
            var element = new RecordElement(name);

            if (elementConfiguration != null)
            {
                elementConfiguration(new RecordElementExpression(element));
            }

            group.AddElement(element);
            
            return this;
        }

        /// <summary>
        /// Adds a group to this record.
        /// </summary>
        /// <param name="groupContentConfiguration">The group content configuration.</param>
        /// <returns>The current expression instance.</returns>
        public IRecordExpression WithGroup(Action<IRecordExpression> groupContentConfiguration) {
            return WithGroup(groupContentConfiguration, null);
        }

        /// <summary>
        /// Adds a group to this record.
        /// </summary>
        /// <param name="groupContentConfiguration">The group content configuration.</param>
        /// <param name="groupConfiguration">The group configuration.</param>
        /// <returns>The current expression instance.</returns>
        public IRecordExpression WithGroup(Action<IRecordExpression> groupContentConfiguration, Action<IRecordGroupExpression> groupConfiguration)
        {
            if (groupContentConfiguration != null) {
                var nestedGroup = new RecordGroup(group.ElementTracker);
                var expression = new RecordExpression(nestedGroup);
                groupContentConfiguration(expression);

                if (nestedGroup.Elements.Count > 0) {
                    group.AddElement(nestedGroup);
                }

                if (groupConfiguration != null)
                {
                    groupConfiguration(new RecordGroupExpression(nestedGroup));
                }
            }

            return this;
        }

        #endregion
    }
}