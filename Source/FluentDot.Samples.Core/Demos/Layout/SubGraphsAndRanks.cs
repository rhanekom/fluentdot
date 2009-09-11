/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;
using FluentDot.Attributes.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout
{
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
                                                           edge.From.NodeWithName("a").To.NodeWithName("b");
                                                           edge.From.NodeWithName("b").To.NodeWithName("c");
                                                           edge.From.NodeWithName("c").To.NodeWithName("d");
                                                       })
                )
                .SubGraphs.Add(s => s.WithName("c1")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.From.NodeWithName("d").To.NodeWithName("e");
                                                           edge.From.NodeWithName("e").To.NodeWithName("f");
                                                           edge.From.NodeWithName("f").To.NodeWithName("g");
                                                       })
                                                      )
                 .SubGraphs.Add(s => s.WithName("c2")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.From.NodeWithName("g").To.NodeWithName("h");
                                                           edge.From.NodeWithName("h").To.NodeWithName("i");
                                                           edge.From.NodeWithName("i").To.NodeWithName("j");
                                                       }))
                .SubGraphs.Add(s => s.WithName("c3")
                                        .WithRank(RankType.Maximum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.From.NodeWithName("j").To.NodeWithName("k");
                                                           edge.From.NodeWithName("k").To.NodeWithName("l");
                                                           edge.From.NodeWithName("l").To.NodeWithName("m");
                                                       }))
                .SubGraphs.Add(s => s.WithName("c4")
                                        .WithRank(RankType.Minimum)
                                        .Edges.Add(edge =>
                                                       {
                                                           edge.From.NodeWithName("m").To.NodeWithName("n");
                                                           edge.From.NodeWithName("n").To.NodeWithName("o");
                                                           edge.From.NodeWithName("o").To.NodeWithName("p");
                                                       }))
            .Edges.Add(edge => {
                edge.From.NodeWithName("aa").To.NodeWithName("a");
                edge.From.NodeWithName("dd").To.NodeWithName("d");
                edge.From.NodeWithName("gg").To.NodeWithName("g");
                edge.From.NodeWithName("jj").To.NodeWithName("j");
                edge.From.NodeWithName("mm").To.NodeWithName("m");

                edge.From.NodeWithName("aa").To.NodeWithName("dd");
                edge.From.NodeWithName("dd").To.NodeWithName("gg");
                edge.From.NodeWithName("gg").To.NodeWithName("jj");
                edge.From.NodeWithName("jj").To.NodeWithName("mm");
            });
            #endregion
        }

        #endregion
    }
}