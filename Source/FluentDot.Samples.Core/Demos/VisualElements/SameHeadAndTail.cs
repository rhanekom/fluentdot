/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements {
    
    /// <summary>
    /// An example of how edges can be set to connect to the same head and tail.
    /// </summary>
    public class SameHeadAndTail : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Same Edge Head and Tails"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "An example of how edges can be set to connect to the same head and tail."; }
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
            #region ExportCode
            return Fluently.CreateDirectedGraph()
                .Edges.Add(edges =>
                {
                    edges.FromNodeWithName("a").ToNodeWithName("X").WithSameHead("Left");
                    edges.FromNodeWithName("b").ToNodeWithName("X").WithSameHead("Left");
                    edges.FromNodeWithName("c").ToNodeWithName("X").WithSameHead("Right");
                    edges.FromNodeWithName("d").ToNodeWithName("X").WithSameHead("Right");
                    edges.FromNodeWithName("X").ToNodeWithName("e").WithSameTail("Left").WithSameHead("Left");
                    edges.FromNodeWithName("a").ToNodeWithName("e").WithSameTail("Left").WithSameHead("Left");
                    edges.FromNodeWithName("X").ToNodeWithName("f").WithSameTail("Right").WithSameHead("Right");
                    edges.FromNodeWithName("d").ToNodeWithName("f").WithSameTail("Right").WithSameHead("Right");
                });
            #endregion
        }

        #endregion
    }
}