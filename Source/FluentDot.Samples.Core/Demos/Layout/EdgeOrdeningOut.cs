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
    /// A demo of the orderining the graph edges out.
    /// </summary>
    public class EdgeOrdeningOut : AbstractGraphDemo
    {
        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName
        {
            get { return "Edge Ordering Out"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description
        {
            get { return "A demo of the orderining the graph edges out."; }
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
            return Fluently.CreateDirectedGraph()
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("a");
                                   nodes.WithName("b");
                                   nodes.WithName("c");
                                   nodes.WithName("d");
                                   nodes.WithName("e");
                                   nodes.WithName("f");
                                   nodes.WithName("g");
                                   nodes.WithName("h");
                               })
                .Edges.Add(edges =>
                               {
                                   edges.From.NodeWithName("a").To.NodeWithName("b");
                                   edges.From.NodeWithName("a").To.NodeWithName("c");
                                   edges.From.NodeWithName("b").To.NodeWithName("c");
                                   edges.From.NodeWithName("c").To.NodeWithName("d");
                                   edges.From.NodeWithName("b").To.NodeWithName("e");
                                   edges.From.NodeWithName("e").To.NodeWithName("g");
                                   edges.From.NodeWithName("e").To.NodeWithName("f");
                                   edges.From.NodeWithName("g").To.NodeWithName("h");
                               })
                .WithEdgeOrdering(Ordering.Out)
                .WithLabel("Out Ordering of edges");
        }

        #endregion
    }
}