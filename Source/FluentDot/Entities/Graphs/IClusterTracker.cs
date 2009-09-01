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
    /// Provides tracking for clusters.
    /// </summary>
    public interface IClusterTracker {

        /// <summary>
        /// Gets the clusters.
        /// </summary>
        /// <value>The clusters.</value>
        IEnumerable<ICluster> Clusters { get; }

        /// <summary>
        /// Adds the cluster to the collection of clusters.
        /// </summary>
        /// <param name="cluster">The cluster to add to the collection.</param>
        void AddCluster(ICluster cluster);
    }
}