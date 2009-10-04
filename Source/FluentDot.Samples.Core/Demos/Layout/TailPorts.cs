/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;
using FluentDot.Attributes.Edges;

namespace FluentDot.Samples.Core.Demos.Layout {
    /// <summary>
    /// A demo of the different head port options available.
    /// </summary>
    public class TailPorts : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Tail Ports"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of the different tail port options available."; }
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
            #region ExportCode
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                {
                    edges.FromNodeWithName("a").ToNodeWithName("b").WithTailPort(CompassPoint.North).WithLabel("North");
                    edges.FromNodeWithName("a").ToNodeWithName("c").WithTailPort(CompassPoint.NorthEast).WithLabel("NorthEast");
                    edges.FromNodeWithName("a").ToNodeWithName("d").WithTailPort(CompassPoint.East).WithLabel("East");
                    edges.FromNodeWithName("a").ToNodeWithName("e").WithTailPort(CompassPoint.SouthEast).WithLabel("SouthEast");
                    edges.FromNodeWithName("a").ToNodeWithName("f").WithTailPort(CompassPoint.South).WithLabel("South");
                    edges.FromNodeWithName("a").ToNodeWithName("g").WithTailPort(CompassPoint.SouthWest).WithLabel("SouthWest");
                    edges.FromNodeWithName("a").ToNodeWithName("h").WithTailPort(CompassPoint.West).WithLabel("West");
                    edges.FromNodeWithName("a").ToNodeWithName("i").WithTailPort(CompassPoint.NorthWest).WithLabel("NorthWest");
                    edges.FromNodeWithName("a").ToNodeWithName("j").WithTailPort(CompassPoint.Appropriate).WithLabel("Appropriate");
                    edges.FromNodeWithName("a").ToNodeWithName("k").WithTailPort(CompassPoint.Center).WithLabel("Center");
                })
                .WithLabel("Head Ports - Labels on edges specify the head port used.");
            #endregion
        }

        #endregion
    }
}