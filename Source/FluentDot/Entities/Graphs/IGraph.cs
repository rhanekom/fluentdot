/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using FluentDot.Common;
using FluentDot.Conventions;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Nodes;

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// A DOT graph.
    /// </summary>
    public interface IGraph : IDotElement, IAttributeBasedEntity {
        
        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        GraphType Type { get; }

        /// <summary>
        /// Gets or sets the name of the graph.
        /// </summary>
        /// <value>The name of the graph.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets a readonly collection of the nodes currently in the graph.
        /// </summary>
        /// <value>The nodes in the graph.</value>
        IEnumerable<IGraphNode> Nodes { get; }

        /// <summary>
        /// Gets the node lookup.
        /// </summary>
        /// <value>The node lookup.</value>
        INodeTracker NodeLookup { get; }

        /// <summary>
        /// Adds the specified node to the graph.
        /// </summary>
        /// <param name="node">The node to add to the graph.</param>
        void AddNode(IGraphNode node);
        
        /// <summary>
        /// Gets a readonly collection of the edges currently in the graph.
        /// </summary>
        /// <value>The edges in the graph.</value>
        IEnumerable<IEdge> Edges { get; }

        /// <summary>
        /// Adds the specified edge to the graph.
        /// </summary>
        /// <param name="edge">The edge to add to the graph.</param>
        void AddEdge(IEdge edge);

        /// <summary>
        /// Gets the edge lookup.
        /// </summary>
        /// <value>The edge lookup.</value>
        IEdgeTracker EdgeLookup { get; }

        /// <summary>
        /// Adds the cluster to the graph.
        /// </summary>
        /// <param name="cluster">The cluster to add.</param>
        void AddCluster(ICluster cluster);

        /// <summary>
        /// Gets the cluster lookup.
        /// </summary>
        /// <value>The cluster lookup.</value>
        IClusterTracker ClusterLookup { get; }

        /// <summary>
        /// Gets the node defaults.
        /// </summary>
        /// <value>The node defaults.</value>
        IEntityDefaults NodeDefaults { get;}

        /// <summary>
        /// Gets the edge defaults.
        /// </summary>
        /// <value>The edge defaults.</value>
        IEntityDefaults EdgeDefaults { get;}

        /// <summary>
        /// Gets the conventions.
        /// </summary>
        /// <value>The conventions.</value>
        IConventionTracker Conventions { get; }

        /// <summary>
        /// Sets the node defaults.
        /// </summary>
        /// <param name="template">The template.</param>
        void SetNodeDefaults(IGraphNode template);

        /// <summary>
        /// Sets the edge defaults.
        /// </summary>
        /// <param name="template">The template.</param>
        void SetEdgeDefaults(IEdge template);
    }
}