/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Linq;
using System.Reflection;
using FluentDot.Attributes.Nodes;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo of the different node styles Dot provides.
    /// </summary>
    public class NodeStyles : AbstractGraphDemo {
        
        #region AbstractGraphDemo Members

        public override string FriendlyName {
            get { return "Node Styles"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of the different node styles that DOT provides."; }
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
            var graph = Fluently.CreateDirectedGraph();

            int a = 1;
            int b = 2;

            foreach (var item in typeof(NodeStyle).GetFields(BindingFlags.Public | BindingFlags.Static).Where(x => typeof(NodeStyle).IsAssignableFrom(x.FieldType))) {
                var style = (NodeStyle)item.GetValue(null);
                graph.Nodes.Add(
                    x =>
                        {
                            x.WithName(a.ToString()).WithStyle(style);
                            x.WithName(b.ToString()).WithStyle(style);
                        })
                    .Edges.Add(
                    x => x.From.NodeWithName(a.ToString()).To.NodeWithName(b.ToString()).WithLabel(item.Name));

                a += 2;
                b += 2;
            }

            return graph;
            #endregion
        }

        #endregion
    }
}