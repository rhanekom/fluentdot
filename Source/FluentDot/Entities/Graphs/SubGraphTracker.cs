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
    /// A concrete implementation of an <see cref="ISubGraphTracker"/>.
    /// </summary>
    public class SubGraphTracker : ISubGraphTracker {

        #region Globals

        private readonly Dictionary<string, ISubGraph> subGraphs = new Dictionary<string, ISubGraph>();

        #endregion

        #region ISubGraphTracker Members

        /// <summary>
        /// Gets the clusters.
        /// </summary>
        /// <value>The clusters.</value>
        public IEnumerable<ISubGraph> Clusters
        {
            get { return subGraphs.Values; }
        }

        /// <summary>
        /// Adds the cluster to the collection of clusters.
        /// </summary>
        /// <param name="cluster">The cluster to add to the collection.</param>
        public void AddSubGraph(ISubGraph cluster)
        {
            subGraphs.Add(cluster.Name, cluster);
        }

        #endregion
    }
}