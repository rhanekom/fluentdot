﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// An expresion for modifying the root instance of a record.
    /// </summary>
    public interface IRootRecordExpression : IRecordExpression {

        /// <summary>
        /// Customizes the specified node configuration.
        /// </summary>
        /// <param name="nodeConfiguration">The node configuration.</param>
        /// <returns>The current expression instance.</returns>
        IRecordExpression Customize(Action<INodeExpression> nodeConfiguration);
    }
}