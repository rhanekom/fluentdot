/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.API
{
    /// <summary>
    /// A demo for the setting node and edge defaults in a graph.
    /// </summary>
    public class Conventions : AbstractGraphDemo
    {
        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
        public override DemoType Type
        {
            get { return DemoType.API; }
        }

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected override IGraphExpression CreateGraph()
        {
            return Fluently.CreateDirectedGraph()
                .Conventions.Setup(x => {
                                            x.AddType<EvenNodeColouringConvention>();
                                            x.AddType<OddNodeColouringConvention>();
                                            x.AddType<NodeTagLabelConvention>();
                                            x.AddType<EvenToOddEdgeConvention>();
                                            x.AddType<OddToEvenEdgeConvention>();
                })
                .Nodes.Add(x =>
                               {
                                   x.WithName("a").WithTag(1);
                                   x.WithName("b").WithTag(2);
                                   x.WithName("c").WithTag(3);
                                   x.WithName("d").WithTag(4);
                                   x.WithName("e").WithTag(5);
                               })
                .Edges.Add(x =>
                               {
                                   x.From.NodeWithName("a").To.NodeWithName("b");
                                   x.From.NodeWithName("a").To.NodeWithName("c");
                                   x.From.NodeWithName("c").To.NodeWithName("d").WithLabel("Label Override");
                                   x.From.NodeWithName("b").To.NodeWithName("d");
                                   x.From.NodeWithName("d").To.NodeWithName("e");
                               })
                .WithLabel(@"Conventions\nEven and odd numbered nodes are coloured differently\nEven to odd and odd to even edges are marked\nThe labels of all nodes are the tags of the nodes");
        }

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName
        {
            get { return "Conventions"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description
        {
            get { return "An illustration of how conventions can simplify decision making in graph formatting."; }
        }

        #endregion
    }
}