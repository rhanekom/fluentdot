/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;
using FluentDot.Attributes.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout {
    /// <summary>
    /// A simple demo of sub graphs and ranks.
    /// </summary>
    public class SubGraphsAndRanks : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Sub Graphs and Ranks"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "Demonstration of how sub graphs and ranking can help with the layout of graphs."; }
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
                .SubGraphs.Add(s => s.WithName("c0")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("a").ToNodeWithName("b");
                                                           edge.FromNodeWithName("b").ToNodeWithName("c");
                                                           edge.FromNodeWithName("c").ToNodeWithName("d");
                                                       })
                )
                .SubGraphs.Add(s => s.WithName("c1")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("d").ToNodeWithName("e");
                                                           edge.FromNodeWithName("e").ToNodeWithName("f");
                                                           edge.FromNodeWithName("f").ToNodeWithName("g");
                                                       })
                                                      )
                 .SubGraphs.Add(s => s.WithName("c2")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("g").ToNodeWithName("h");
                                                           edge.FromNodeWithName("h").ToNodeWithName("i");
                                                           edge.FromNodeWithName("i").ToNodeWithName("j");
                                                       }))
                .SubGraphs.Add(s => s.WithName("c3")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("j").ToNodeWithName("k");
                                                           edge.FromNodeWithName("k").ToNodeWithName("l");
                                                           edge.FromNodeWithName("l").ToNodeWithName("m");
                                                       }))
                .SubGraphs.Add(s => s.WithName("c4")
                                        .WithRank(RankType.Minimum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.FromNodeWithName("m").ToNodeWithName("n");
                                                           edge.FromNodeWithName("n").ToNodeWithName("o");
                                                           edge.FromNodeWithName("o").ToNodeWithName("p");
                                                       }))
            .Edges.Add(edge => {
                edge.FromNodeWithName("aa").ToNodeWithName("a");
                edge.FromNodeWithName("dd").ToNodeWithName("d");
                edge.FromNodeWithName("gg").ToNodeWithName("g");
                edge.FromNodeWithName("jj").ToNodeWithName("j");
                edge.FromNodeWithName("mm").ToNodeWithName("m");

                edge.FromNodeWithName("aa").ToNodeWithName("dd");
                edge.FromNodeWithName("dd").ToNodeWithName("gg");
                edge.FromNodeWithName("gg").ToNodeWithName("jj");
                edge.FromNodeWithName("jj").ToNodeWithName("mm");
            });
            #endregion
        }

        #endregion
    }
}