/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// An implementation of a cluster.
    /// </summary>
    public class Cluster : AbstractGraph, ICluster {

        #region Globals

        private readonly GraphType clusterType = GraphType.Undirected;
        private string name;
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Cluster"/> class.
        /// </summary>
        /// <param name="parentGraph">The parent graph.</param>
        public Cluster(IGraph parentGraph)
            : base(parentGraph.NodeLookup, parentGraph.EdgeLookup)
        {
            clusterType = parentGraph.Type;
            Name = Guid.NewGuid().ToString("N");
        }

        #endregion

        #region AbstractGraph Members

        /// <summary>
        /// Gets or sets the name of the graph.
        /// </summary>
        /// <value>The name of the graph.</value>
        public override sealed string Name {
            get { return name; }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value");
                }

                if (value.StartsWith("cluster")) 
                {
                    name = value;
                } else 
                {
                    name = "cluster" + value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public override GraphType Type {
            get { return clusterType; }
        }

        /// <summary>
        /// Gets the graph indicator.
        /// </summary>
        /// <value>The graph indicator.</value>
        protected override string GraphIndicator {
            get { return "subgraph"; }
        }

        #endregion
    }
}