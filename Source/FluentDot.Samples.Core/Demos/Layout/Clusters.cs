/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout
{
    /// <summary>
    /// A simple demo of clustering graphs.
    /// </summary>
    public class Clusters : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Clusters"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of how clusters can be used to partition a graph."; }
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
            
            return Fluently.CreateDirectedGraph()
                .Clusters.Add(c0 => c0
                                        .WithName("c0")
                                        .Nodes.Add(nodes =>
                                                       {
                                                           nodes.WithName("a0");
                                                           nodes.WithName("a1");
                                                           nodes.WithName("a2");
                                                           nodes.WithName("a3");
                                                       })
                                        .Edges.Add(edges =>
                                                       {
                                                           edges.From.NodeWithName("a0").To.NodeWithName("a1");
                                                           edges.From.NodeWithName("a1").To.NodeWithName("a2");
                                                           edges.From.NodeWithName("a2").To.NodeWithName("a3");
                                                       })
                )
                .Clusters.Add(c1 => c1
                                        .WithName("c1")
                                        .WithBackgroundColor(Color.Gainsboro)
                                        .Nodes.Add(nodes =>
                                                       {
                                                           nodes.WithName("b0");
                                                           nodes.WithName("b1");
                                                           nodes.WithName("b2");
                                                           nodes.WithName("b3");
                                                       })
                                        .Edges.Add(edges =>
                                                       {
                                                           edges.From.NodeWithName("b0").To.NodeWithName("b1");
                                                           edges.From.NodeWithName("b1").To.NodeWithName("b2");
                                                           edges.From.NodeWithName("b2").To.NodeWithName("b3");
                                                       }) 
                )
                .Nodes.Add(nodes => {
                                        nodes.WithName("x");
                                        nodes.WithName("z");
                })
                .Edges.Add(edges =>
                               {
                                   edges.From.NodeWithName("x").To.NodeWithName("a0");
                                   edges.From.NodeWithName("x").To.NodeWithName("b0");
                                   edges.From.NodeWithName("a1").To.NodeWithName("b1");
                                   edges.From.NodeWithName("a3").To.NodeWithName("a0");
                                   edges.From.NodeWithName("a3").To.NodeWithName("z");
                                   edges.From.NodeWithName("b3").To.NodeWithName("z");
                               });
        }

        #endregion
    }
}