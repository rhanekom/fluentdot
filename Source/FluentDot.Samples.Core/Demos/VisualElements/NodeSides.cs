/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;
using FluentDot.Attributes.Nodes;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo of applying different sides to nodes with a shape of polygon.
    /// </summary>
    public class NodeSides : AbstractGraphDemo
    {
        #region AbstractGraphDemo Members

        public override string FriendlyName
        {
            get { return "Node Sides"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description
        {
            get { return "A demo of applying different sides to nodes with a shape of polygon."; }
        }

        /// <summary>
        /// Gets or sets the type of demo.
        /// </summary>
        /// <value>The type of demo.</value>
        public override DemoType Type
        {
            get { return DemoType.VisualElements; }
        }

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected override IGraphExpression CreateGraph()
        {
            #region ExportCode
            var graph = Fluently.CreateDirectedGraph()
                .TheDefaults.ForNodes.Are(x => x.WithShape(NodeShape.Polygon))
                .WithLabel("Polygon node sides. The labels on the nodes indicate the number of sides.");

            int a = 1;
            int b = 2;

            for (int i = 0; i < 10; i += 1)
            {
                graph.Nodes.Add(
                    x =>
                    {
                        x.WithName(a.ToString()).WithSides(i).WithLabel(i.ToString());
                        x.WithName(b.ToString()).WithSides(i).WithLabel(i.ToString());
                    })
                    .Edges.Add(
                        x => x.FromNodeWithName(a.ToString()).ToNodeWithName(b.ToString())
                    );

                a += 2;
                b += 2;
            }

            return graph;
            #endregion
        }

        #endregion
    }
}