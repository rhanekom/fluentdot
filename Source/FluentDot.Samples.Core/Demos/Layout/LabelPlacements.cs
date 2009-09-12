/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout
{
    /// <summary>
    /// A simple demo of the different label placement options available.
    /// </summary>
    public class LabelPlacements : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Label Placements"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of the different label placement options available."; }
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
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("a").WithLabelLocation(Location.Bottom).WithLabel("Location - Bottom").WithHeight(1).WithWidth(2);
                                   nodes.WithName("b").DoNotJustify().WithLabel(@"Label\nNot\nJustified");
                                   nodes.WithName("d").WithLabelLocation(Location.Top).WithLabel("Location - Top").WithHeight(1).WithWidth(2);
                                   nodes.WithName("e").DoNotJustify().WithLabel(@"Label\nNot\nJustified");
                                   nodes.WithName("f").WithLabelLocation(Location.Bottom).WithLabel("Location - Bottom").WithHeight(1).WithWidth(2);
                                   nodes.WithName("g").WithLabelLocation(Location.Top).WithLabel("Location - Top").WithHeight(1).WithWidth(2); ;
                               })
                .Edges.Add(edges =>
                               {
                                   edges.From.NodeWithName("a").To.NodeWithName("b");
                                   edges.From.NodeWithName("a").To.NodeWithName("c");
                                   edges.From.NodeWithName("b").To.NodeWithName("c");
                                   edges.From.NodeWithName("c").To.NodeWithName("d").DoNotJustify().WithLabel(@"Label\nNot\nJustified");
                                   edges.From.NodeWithName("b").To.NodeWithName("e");
                                   edges.From.NodeWithName("e").To.NodeWithName("f").DoNotJustify().WithLabel(@"Label\nNot\nJustified");
                                   edges.From.NodeWithName("e").To.NodeWithName("g");
                                   edges.From.NodeWithName("g").To.NodeWithName("h");
                               })
                .WithLabel("Bottom Right Graph Label")
                .WithLabelJustification(Justification.Right)
                .WithLabelLocation(Location.Bottom);
            #endregion
        }

        #endregion
    }
}