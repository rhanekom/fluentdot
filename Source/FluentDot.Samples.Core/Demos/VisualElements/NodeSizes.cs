/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo of the different node styles Dot provides.
    /// </summary>
    public class NodeSizes : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        public override string FriendlyName {
            get { return "Node Sizing"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of the different node sizing properties that DOT provides."; }
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
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("TinyHeight_Expanded").WithHeight(0.1).WithWidth(1.5);
                                   nodes.WithName("TinyWidth_Expanded").WithHeight(1.5).WithWidth(0.1);
                                   nodes.WithName("Fixed_Size1").WithHeight(0.5).WithWidth(0.5).IsFixedSize();
                                   nodes.WithName("Fixed_Size2").WithHeight(0.5).WithWidth(0.5).IsFixedSize();
                               })
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("TinyHeight_Expanded").ToNodeWithName("TinyWidth_Expanded");
                                   edges.FromNodeWithName("TinyHeight_Expanded").ToNodeWithName("Fixed_Size1");
                                   edges.FromNodeWithName("TinyWidth_Expanded").ToNodeWithName("Fixed_Size1");
                                   edges.FromNodeWithName("Fixed_Size1").ToNodeWithName("Fixed_Size2");
                               });
            #endregion
        }

        #endregion
    }
}