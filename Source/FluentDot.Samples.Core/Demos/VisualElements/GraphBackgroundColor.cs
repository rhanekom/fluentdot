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
    /// A demo for the graph background color.
    /// </summary>
    public class GraphBackgroundColor : AbstractGraphDemo {

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
                .Edges.Add(x =>
                               {
                                   x.FromNodeWithName("a").ToNodeWithName("b");
                                   x.FromNodeWithName("a").ToNodeWithName("c");
                                   x.FromNodeWithName("c").ToNodeWithName("d");
                                   x.FromNodeWithName("b").ToNodeWithName("d");
                               }
                ).WithBackgroundColor(Color.SlateBlue);
            #endregion
        }

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName {
            get { return "Graph Background Color"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "An illustration of the background color functionality in a graph."; }
        }

        #endregion
    }
}