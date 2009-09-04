/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// A concrete implementation of a <see cref="IClusterCollectionAddExpression"/>.
    /// </summary>
    public class ClusterCollectionAddExpression : IClusterCollectionAddExpression
    {
        #region Globals

        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterCollectionAddExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public ClusterCollectionAddExpression(IGraph graph)
        {
            this.graph = graph;
        }

        #endregion

        #region IClusterCollectionAddExpression Members

        /// <summary>
        /// Adds a cluster with the specified name to the graph.
        /// </summary>
        /// <param name="name">The name of the cluster to create.</param>
        /// <returns>
        /// A cluster expression for configuring the clsuter.
        /// </returns>
        public IClusterExpression WithName(string name)
        {
            var expression = new ClusterExpression(graph);
            expression.Cluster.Name = name;
            graph.AddCluster(expression.Cluster);
            return expression;
        }

        #endregion
    }
}