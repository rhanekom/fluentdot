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
    /// An implementation of a subgraph.
    /// </summary>
    public class SubGraph : AbstractGraph, ISubGraph
    {
        #region Globals

        private readonly GraphType subGraphType = GraphType.Undirected;
        private readonly IGraph parentGraph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Cluster"/> class.
        /// </summary>
        /// <param name="parentGraph">The parent graph.</param>
        public SubGraph(IGraph parentGraph)
            : base(parentGraph.NodeLookup, parentGraph.EdgeLookup, new SubGraphTracker())
        {
            subGraphType = parentGraph.Type;
            Name = Guid.NewGuid().ToString("N");
            this.parentGraph = parentGraph;
        }
        
        #endregion

        #region AbstractGraph Members

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public override GraphType Type
        {
            get { return subGraphType; }
        }

        /// <summary>
        /// Gets the graph indicator.
        /// </summary>
        /// <value>The graph indicator.</value>
        protected override string GraphIndicator
        {
            get { return "subgraph"; }
        }

        #endregion

        #region Public members

        /// <summary>
        /// Gets the parent graph.
        /// </summary>
        /// <value>The parent graph.</value>
        public IGraph Parent {
            get { return parentGraph; }
        }

        #endregion
    }
}