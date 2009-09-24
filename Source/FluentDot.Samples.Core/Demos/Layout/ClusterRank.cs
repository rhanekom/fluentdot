/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Expressions.Graphs;
using FluentDot.Attributes.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout {
    /// <summary>
    /// A demo of the cluster rank attribute.
    /// </summary>
    public class ClusterRank : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Cluster Rank"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of how global cluster rank affects the layout of clusters."; }
        }

        /// <summary>
        /// Gets or sets the type of demo.
        /// </summary>
        /// <value>The type of demo.</value>
        public override DemoType Type {
            get { return DemoType.Layout; }
        }

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected override IGraphExpression CreateGraph() {
            #region ExportCode
            return Fluently.CreateDirectedGraph()
                .Clusters.Add(c0 => c0
                                        .WithName("c0")
                                        .WithBackgroundColor(Color.LightSteelBlue)
                                        .Edges.Add(edges => edges.FromNodeWithName("a0").ToNodeWithName("a1"))
                .Clusters.Add(c1 => c1
                                        .WithName("c1")
                                        .WithBackgroundColor(Color.LightSlateGray)
                                        .Edges.Add(edges => edges.FromNodeWithName("b0").ToNodeWithName("b1"))
                )
                .Edges.Add(edges => edges.FromNodeWithName("a0").ToNodeWithName("b0")))
                .WithClusterRankMode(ClusterMode.Global);
            #endregion
        }

        #endregion
    }
}