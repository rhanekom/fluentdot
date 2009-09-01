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
    /// A concrete implementation of an <see cref="IRootRecordExpression"/>.
    /// </summary>
    public class RootRecordExpression : RecordExpression, IRootRecordExpression {

        #region Globals
        
        private readonly IRecordNode recordNode;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RootRecordExpression"/> class.
        /// </summary>
        /// <param name="recordNode">The record node.</param>
        public RootRecordExpression(IRecordNode recordNode) : base(recordNode.RecordGroup)
        {
            this.recordNode = recordNode;
        }

        #endregion

        #region IRootRecordExpression Members

        /// <summary>
        /// Customizes the specified node configuration.
        /// </summary>
        /// <param name="nodeConfiguration">The node configuration.</param>
        /// <returns>The current expression instance.</returns>
        public IRecordExpression Customize(Action<INodeExpression> nodeConfiguration) {

            if (nodeConfiguration != null)
            {
                nodeConfiguration(new NodeExpression(recordNode));
            }

            return this;
        }

        #endregion
    }
}