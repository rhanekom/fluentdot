/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo of the different parameters available on edge labels.
    /// </summary>
    public class EdgeLabels : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Edge Head and Tail Labels"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of applying different parameters to edge head and tail labels."; }
        }

        /// <summary>
        /// Gets or sets the type of demo.
        /// </summary>
        /// <value>The type of demo.</value>
        public override DemoType Type {
            get { return DemoType.VisualElements; }
        }

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected override IGraphExpression CreateGraph() {
            return Fluently.CreateDirectedGraph()
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("a");
                                   nodes.WithName("b");
                                   nodes.WithName("c");
                                   nodes.WithName("d");
                                   nodes.WithName("e");
                                   nodes.WithName("f");
                                   nodes.WithName("g");
                                   nodes.WithName("h");
                               })
                .Edges.Add(edges =>
                               {
                                   edges.From.NodeWithName("a").To.NodeWithName("b").WithLabelAngle(100).WithTailLabel("Angle : 100");
                                   edges.From.NodeWithName("a").To.NodeWithName("c").WithLabelAngle(-100).WithHeadLabel("Angle : -100");
                                   edges.From.NodeWithName("b").To.NodeWithName("c").FloatLabel().WithLabel("Floating Label");
                                   edges.From.NodeWithName("c").To.NodeWithName("d").WithLabelDistance(5).WithHeadLabel("Distance : 50");
                                   edges.From.NodeWithName("b").To.NodeWithName("e").WithLabelDistance(0.5).WithTailLabel("Distance : 0.5");
                                   edges.From.NodeWithName("e").To.NodeWithName("f").WithLabelFontColor(Color.Blue).WithLabelFontSize(28).WithLabelFontName("Times-Roman").WithHeadLabel("Blue Times-Roman 28 Point");
                                   edges.From.NodeWithName("e").To.NodeWithName("g").FloatLabel().WithLabel("Floating Label");
                                   edges.From.NodeWithName("g").To.NodeWithName("h").WithLabelFontColor(Color.Red).WithLabelFontSize(7).WithLabelFontName("Helvetica").WithTailLabel("Red Helvetica 14 Point");
                               }
                );
        }

        #endregion
    }
}