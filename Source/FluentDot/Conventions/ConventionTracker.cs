/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using System;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Edges;
using FluentDot.Expressions.Nodes;
using FluentDot.Expressions.Edges;

namespace FluentDot.Conventions
{
    /// <summary>
    /// A concrete implementation of an <see cref="IConventionTracker"/>.
    /// </summary>
    public class ConventionTracker : IConventionTracker
    {
        #region Globals

        private readonly List<IEdgeConvention> edgeConventions = new List<IEdgeConvention>();
        private readonly List<INodeConvention> nodeConventions = new List<INodeConvention>();

        #endregion

        #region IConventionTracker Members

        /// <summary>
        /// Adds the specified convention to the tracker.
        /// </summary>
        /// <param name="convention">The convention to add to this instance.</param>
        public void AddConvention(IEdgeConvention convention)
        {
            if (convention == null)
            {
                throw new ArgumentNullException("convention");
            }
            
            edgeConventions.Add(convention);
        }

        /// <summary>
        /// Adds the specified convention to the tracker.
        /// </summary>
        /// <param name="convention">The convention to add to this instance.</param>
        public void AddConvention(INodeConvention convention)
        {
            if (convention == null)
            {
                throw new ArgumentNullException("convention");
            }

            nodeConventions.Add(convention);
        }

        /// <summary>
        /// Applies the known conventions to the specified node.
        /// </summary>
        /// <param name="node">The node to apply the conventions to.</param>
        public void ApplyConventions(IGraphNode node)
        {
            for (int i = 0; i< nodeConventions.Count; i++)
            {
                var convention = nodeConventions[i];
                var nodeInfo = new NodeInfo(node.Name, node.Tag);

                if (convention.ShouldApply(nodeInfo))
                {
                    convention.Apply(nodeInfo, new NodeExpression(node));
                }
            }
        }

        /// <summary>
        /// Applies the known conventions to the specified edge.
        /// </summary>
        /// <param name="edge">The edge to apply the conventions to.</param>
        public void ApplyConventions(IEdge edge)
        {
            for (int i = 0; i < edgeConventions.Count; i++)
            {
                var convention = edgeConventions[i];
                var edgeInfo = new EdgeInfo(edge);
                    
                if (convention.ShouldApply(edgeInfo))
                {
                    convention.Apply(edgeInfo, new EdgeExpression(edge));
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the edge conventions.
        /// </summary>
        /// <value>The edge conventions.</value>
        public IList<IEdgeConvention> EdgeConventions { get { return edgeConventions; } }

        /// <summary>
        /// Gets the node conventions.
        /// </summary>
        /// <value>The node conventions.</value>
        public IList<INodeConvention> NodeConventions { get { return nodeConventions; } }

        #endregion
    }
}