/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Demos.Layout {

    /// <summary>
    /// A demo of graph and node margins and padding.
    /// </summary>
    public class MarginsAndPadding : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Margins and Padding"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of graph and node margins and padding."; }
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
                .Nodes.Add(nodes =>
                {
                    nodes.WithName("a");
                    nodes.WithName("b").WithLabelMargin(0.5f, 0.5f).WithLabel("0.5 Point Margin");
                    nodes.WithName("c");
                    nodes.WithName("d");
                    nodes.WithName("e").WithLabelMargin(1, 1).WithLabel("1 Point Margin");
                    nodes.WithName("f");
                    nodes.WithName("g").WithLabelMargin(2, 2).WithLabel("2 Point Margin");
                    nodes.WithName("h");
                })
                .Edges.Add(edges =>
                {
                    edges.From.NodeWithName("a").To.NodeWithName("b");
                    edges.From.NodeWithName("a").To.NodeWithName("c");
                    edges.From.NodeWithName("b").To.NodeWithName("c");
                    edges.From.NodeWithName("c").To.NodeWithName("e");
                    edges.From.NodeWithName("e").To.NodeWithName("f");
                    edges.From.NodeWithName("e").To.NodeWithName("g");
                })
                .WithBackgroundColor(Color.Gainsboro)
                .WithLabel("2 Point Graph Margin, 1 Inch Margin Around Graph")
                .WithMargin(2, 2)
                .WithPadding(1, 1);
        }

        #endregion
    }
}
