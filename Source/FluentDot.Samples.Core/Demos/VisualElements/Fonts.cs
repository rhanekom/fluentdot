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
    /// A demo of the different node styles Dot provides.
    /// </summary>
    public class Fonts : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        public override string FriendlyName {
            get { return "Font Colors, Sizes, and Names"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of the different font styles that DOT provides."; }
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
        protected override IGraphExpression CreateGraph()
        {
            #region ExportCode
            return Fluently.CreateDirectedGraph()
                .WithLabel("Courier Purple SizedUp Graph Label")
                .WithFontColor(Color.Purple)
                .WithFontSize(28)
                .WithFontName("Courier")
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("RedFont").WithFontColor(Color.Red);
                                   nodes.WithName("BlueFont").WithFontColor(Color.Blue);
                                   nodes.WithName("SizeUp").WithFontSize(28.0);
                                   nodes.WithName("SizeDown").WithFontSize(7.0);
                                   nodes.WithName("TimesRoman").WithFontName("Times-Roman");
                                   nodes.WithName("Helvetica").WithFontName("Helvetica");
                                   nodes.WithName("Courier").WithFontName("Courier");
                               })
                .Edges.Add(edges =>
                               {
                                   edges.From.NodeWithName("RedFont").To.NodeWithName("BlueFont").WithFontColor(Color.Brown).WithLabel("BrownFont");
                                   edges.From.NodeWithName("RedFont").To.NodeWithName("SizeUp").WithFontColor(Color.HotPink).WithLabel("HotPink");
                                   edges.From.NodeWithName("BlueFont").To.NodeWithName("SizeUp");
                                   edges.From.NodeWithName("SizeUp").To.NodeWithName("SizeDown");
                                   edges.From.NodeWithName("BlueFont").To.NodeWithName("NormalSize").WithFontSize(28.0).WithLabel("SizeUp");
                                   edges.From.NodeWithName("NormalSize").To.NodeWithName("TimesRoman").WithFontSize(7.0).WithLabel("SizeDown");
                                   edges.From.NodeWithName("NormalSize").To.NodeWithName("Helvetica").WithFontName("Times-Roman").WithLabel("Times-Roman");
                                   edges.From.NodeWithName("Helvetica").To.NodeWithName("Courier").WithFontName("Helvetica").WithLabel("Helvetica");
                               });
            #endregion
        }

        #endregion
    }
}