/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout {
    
    /// <summary>
    /// A demo of how the compound attribute enables logical heads and tails between clusters.
    /// </summary>
    public class LogicalHeadsAndTails : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Logical Heads and Tails"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of how the compound attribute enables logical heads and tails between clusters."; }
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
                                        .Edges.Add(edges =>
                                        {
                                            edges.FromNodeWithName("a0").ToNodeWithName("a1");
                                            edges.FromNodeWithName("a1").ToNodeWithName("a2");
                                        })
                                      )
                .Clusters.Add(c1 => c1
                                        .WithName("c1")
                                        .WithBackgroundColor(Color.Gainsboro)
                                        .Edges.Add(edges =>
                                        {
                                            edges.FromNodeWithName("b0").ToNodeWithName("b1");
                                            edges.FromNodeWithName("b1").ToNodeWithName("b2");
                                        })
                )
                .Edges.Add(edges =>
                {
                    edges.FromNodeWithName("x").ToNodeWithName("a0").WithLogicalHead("c0").WithLabel("Logical Head");
                    edges.FromNodeWithName("b2").ToNodeWithName("y").WithLogicalTail("c1").WithLabel("Logical Tail");
                    edges.FromNodeWithName("f").ToNodeWithName("a0").WithLabel("Normal");
                    edges.FromNodeWithName("b2").ToNodeWithName("g").WithLabel("Normal");
                })
                .Compound();
            #endregion
        }

        #endregion
    }
}