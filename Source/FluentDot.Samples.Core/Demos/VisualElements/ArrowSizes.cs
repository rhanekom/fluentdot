/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo of arrow sizes in DOT.
    /// </summary>
    public class ArrowSizes : AbstractGraphDemo  {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName {
            get { return "Arrow Sizes"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of the arrow sizing that DOT supports."; }
        }

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected override IGraphExpression CreateGraph()
        {
            #region ExportCode
            var graph = Fluently.CreateDirectedGraph();
            
            int a = 1;
            int b = 2;

            for (double i = 0; i <= 2; i += 0.2)
            {
                graph.Nodes.Add(
                    x =>
                        {
                            x.WithName(a.ToString());
                            x.WithName(b.ToString());
                        })
                    .Edges.Add(
                    x => x.From.NodeWithName(a.ToString()).To.NodeWithName(b.ToString())
                             .WithArrowSize(i))
                    .WithLabel(i.ToString());

                a += 2;
                b += 2;
            }

            return graph;
            #endregion
        }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
        public override DemoType Type {
            get { return DemoType.VisualElements; }
        }

        #endregion
    }
}