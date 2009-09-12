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
        protected override IGraphExpression CreateGraph()
        {
            #region ExportCode
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b").WithLabelAngle(100).WithTailLabel("Angle : 100");
                                   edges.FromNodeWithName("a").ToNodeWithName("c").WithLabelAngle(-100).WithHeadLabel("Angle : -100");
                                   edges.FromNodeWithName("b").ToNodeWithName("c").FloatLabel().WithLabel("Floating Label");
                                   edges.FromNodeWithName("c").ToNodeWithName("d").WithLabelDistance(5).WithHeadLabel("Distance : 50");
                                   edges.FromNodeWithName("b").ToNodeWithName("e").WithLabelDistance(0.5).WithTailLabel("Distance : 0.5");
                                   edges.FromNodeWithName("e").ToNodeWithName("f").WithLabelFontColor(Color.Blue).WithLabelFontSize(28).WithLabelFontName("Times-Roman").WithHeadLabel("Blue Times-Roman 28 Point");
                                   edges.FromNodeWithName("e").ToNodeWithName("g").FloatLabel().WithLabel("Floating Label");
                                   edges.FromNodeWithName("g").ToNodeWithName("h").WithLabelFontColor(Color.Red).WithLabelFontSize(7).WithLabelFontName("Helvetica").WithTailLabel("Red Helvetica 14 Point");
                                   edges.FromNodeWithName("g").ToNodeWithName("i").Decorate().WithLabel("Decorated Label");
                                   edges.FromNodeWithName("e").ToNodeWithName("j").Decorate().WithLabel("Decorated Label");
                               }
                )
                .WithMinimumNodeSeperation(2);
            #endregion
        }

        #endregion
    }
}