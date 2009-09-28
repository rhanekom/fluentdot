/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Graphs;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout
{
    /// <summary>
    /// A demo of how rank direction affects the layout of a graph.
    /// </summary>
    public class GraphRankDirection : AbstractGraphDemo
    {
        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName
        {
            get { return "Rank Direction"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description
        {
            get { return "A demo of how rank direction affects the layout of a graph."; }
        }

        /// <summary>
        /// Gets or sets the type of demo.
        /// </summary>
        /// <value>The type of demo.</value>
        public override DemoType Type
        {
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
                .Edges.Add(edge =>
                               {
                                   edge.FromNodeWithName("a").ToNodeWithName("b");
                                   edge.FromNodeWithName("b").ToNodeWithName("c");
                                   edge.FromNodeWithName("c").ToNodeWithName("d");
                                   edge.FromNodeWithName("d").ToNodeWithName("e");
                                   edge.FromNodeWithName("e").ToNodeWithName("f");
                                   edge.FromNodeWithName("f").ToNodeWithName("g");
                                   edge.FromNodeWithName("aa").ToNodeWithName("a");
                                   edge.FromNodeWithName("dd").ToNodeWithName("d");
                                   edge.FromNodeWithName("gg").ToNodeWithName("g");
                               }
                )
                .WithRankDirection(RankDirection.RightToLeft)
                .WithLabel("Right To Left layout direction");
            
            #endregion
        }

        #endregion
    }
}