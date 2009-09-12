/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes.Nodes;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A simple directed graph.
    /// </summary>
    public class NodeAndEdgeColors : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
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
                .Nodes.Add(x =>
                               {
                                   x.WithName("Red").WithColor(Color.Red);
                                   x.WithName("Green").WithColor(Color.Green);
                                   x.WithName("Blue").WithColor(Color.Blue);
                                   x.WithName("Yellow").WithColor(Color.Yellow);
                                   x.WithName("Cyan").WithColor(Color.Cyan);
                                   x.WithName("FilledBrown").WithFillColor(Color.Brown).WithStyle(NodeStyle.Filled);
                                   x.WithName("FilledGoldenRod").WithFillColor(Color.Goldenrod).WithStyle(NodeStyle.Filled);
                               }
                )
                .Edges.Add(x =>
                               {
                                   x.FromNodeWithName("Red").ToNodeWithName("Green").WithColor(Color.Coral).WithLabel("Coral");
                                   x.FromNodeWithName("Red").ToNodeWithName("Blue").WithColor(Color.DarkOrange).WithLabel("DarkOrange");
                                   x.FromNodeWithName("Blue").ToNodeWithName("Yellow").WithColor(Color.DeepSkyBlue).WithLabel("DeepSkyBlue");
                                   x.FromNodeWithName("Blue").ToNodeWithName("Cyan").WithColor(Color.Chocolate).WithLabel("Chocolate");
                                   x.FromNodeWithName("Cyan").ToNodeWithName("FilledBrown").WithColor(Color.Purple).WithLabel("Purple");
                                   x.FromNodeWithName("Cyan").ToNodeWithName("FilledGoldenRod").WithColor(Color.HotPink).WithLabel("HotPink");
                               }
                );
            #endregion
        }

        public override string FriendlyName {
            get { return "Node and Edge Colors"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "An illustration of the node and edge coloring functionality in a graph."; }
        }

        #endregion
    }
}