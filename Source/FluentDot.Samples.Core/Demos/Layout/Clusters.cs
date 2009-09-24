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
        protected override IGraphExpression CreateGraph()
        {
            #region ExportCode
            return Fluently.CreateDirectedGraph()
                .Clusters.Add(c0 => c0
                                        .WithName("c0")
                                        .Edges.Add(edges =>
                                                       {
                                                           edges.FromNodeWithName("a0").ToNodeWithName("a1");
                                                           edges.FromNodeWithName("a1").ToNodeWithName("a2");
                                                           edges.FromNodeWithName("a2").ToNodeWithName("a3");
                                                       })
                                        .Clusters.Add(c00 => c00
                                            .WithName("c00")
                                            .Edges.Add(edges =>
                                                           {
                                                               edges.FromNodeWithName("a3").ToNodeWithName("a4");
                                                               edges.FromNodeWithName("a4").ToNodeWithName("a5");
                                                           })
                                             .WithColor(Color.Red)
                                            ))
                .Clusters.Add(c1 => c1
                                        .WithName("c1")
                                        .WithBackgroundColor(Color.Gainsboro)
                                        .Edges.Add(edges =>
                                                       {
                                                           edges.FromNodeWithName("b0").ToNodeWithName("b1");
                                                           edges.FromNodeWithName("b1").ToNodeWithName("b2");
                                                           edges.FromNodeWithName("b2").ToNodeWithName("b3");
                                                       }) 
                )
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("x").ToNodeWithName("a0");
                                   edges.FromNodeWithName("x").ToNodeWithName("b0");
                                   edges.FromNodeWithName("a1").ToNodeWithName("b1");
                                   edges.FromNodeWithName("a5").ToNodeWithName("a0");
                                   edges.FromNodeWithName("a3").ToNodeWithName("z");
                                   edges.FromNodeWithName("b3").ToNodeWithName("z");
                               });
            #endregion
        }

        #endregion
    }
}