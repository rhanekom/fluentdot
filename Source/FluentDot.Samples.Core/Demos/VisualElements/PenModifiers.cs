/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;
using System.Drawing;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo of how the drawing pen can be modified.
    /// </summary>
    public class PenModifiers : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Pen Modifiers"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of how the drawing pen can be modified."; }
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
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("b").WithPenWidth(2.0).WithLabel("Pen Width : 2.0");
                                   nodes.WithName("d").WithPenWidth(3.0).WithLabel("Pen Width : 3.0");
                               })
                .Clusters.Add(cluster => cluster
                                             .WithName("sub")
                                             .Nodes.Add(nodes =>
                                                            {
                                                                nodes.WithName("e");
                                                                nodes.WithName("f").WithPenWidth(1.5).WithLabel("Pen Width : 1.5");
                                                                nodes.WithName("g");
                                                                nodes.WithName("h").WithPenWidth(0).WithLabel("Pen Width : 0");
                                                            })
                                             .WithPenColor(Color.Red)
                                             .WithPenWidth(2.0)
                                             .WithLabel("Red pen color, 2.0 Width"))
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b");
                                   edges.FromNodeWithName("b").ToNodeWithName("c");
                                   edges.FromNodeWithName("b").ToNodeWithName("d");
                                   edges.FromNodeWithName("c").ToNodeWithName("d").WithPenWidth(2.0).WithLabel("Pen Width : 2.0");
                                   edges.FromNodeWithName("b").ToNodeWithName("e");
                                   edges.FromNodeWithName("e").ToNodeWithName("f");
                                   edges.FromNodeWithName("e").ToNodeWithName("g");
                                   edges.FromNodeWithName("g").ToNodeWithName("h");
                                   edges.FromNodeWithName("f").ToNodeWithName("g").WithPenWidth(3.0).WithLabel("Pen Width : 3.0");
                                   edges.FromNodeWithName("g").ToNodeWithName("a");
                               });
            #endregion
        }

        #endregion
    }
}