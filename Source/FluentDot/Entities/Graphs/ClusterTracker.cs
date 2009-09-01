/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// A concrete implementation of an <see cref="IClusterTracker"/>.
    /// </summary>
    public class ClusterTracker : IClusterTracker {

        #region Globals

        private readonly Dictionary<string, ICluster> clusters = new Dictionary<string, ICluster>();

        #endregion

        #region IClusterTracker Members

        /// <summary>
        /// Gets the clusters.
        /// </summary>
        /// <value>The clusters.</value>
        public IEnumerable<ICluster> Clusters
        {
            get { return clusters.Values; }
        }

        /// <summary>
        /// Adds the cluster to the collection of clusters.
        /// </summary>
        /// <param name="cluster">The cluster to add to the collection.</param>
        public void AddCluster(ICluster cluster)
        {
            clusters.Add(cluster.Name, cluster);
        }

        #endregion
    }
}