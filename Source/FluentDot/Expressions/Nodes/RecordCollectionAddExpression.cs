/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// A concrete implementaiton of an <see cref="IRecordCollectionAddExpression"/>
    /// </summary>
    public class RecordCollectionAddExpression : IRecordCollectionAddExpression {
        
        #region Globals

        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordCollectionAddExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public RecordCollectionAddExpression(IGraph graph)
        {
            this.graph = graph;
        }

        #endregion

        #region IRecordCollectionAddExpression Members

        /// <summary>
        /// Adds a record node with the specified name to the graph.
        /// </summary>
        /// <param name="name">The name of the record node to create.</param>
        /// <returns>
        /// A record expression for configuring the record.
        /// </returns>
        public IRootRecordExpression WithName(string name) {
            var recordGroup = new RecordGroup();
            var node = new RecordNode(name, recordGroup);
            
            graph.AddNode(node);

            var expression = new RootRecordExpression(node);
            return expression;
        }

        #endregion
    }
}