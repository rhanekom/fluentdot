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

namespace FluentDot.Samples.Demos.VisualElements
{
    /// <summary>
    /// A demo showing off the different node shapes that are available.
    /// </summary>
    public class NodeShapes : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        public override string FriendlyName {
            get { return "Node Shapes"; }
        }

        public override string Description {
            get { return "Showing off all possible shapes available through Dot."; }
        }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
        public override DemoType Type {
            get { return DemoType.VisualElements; }
        }

        protected override IGraphExpression CreateGraph() {
            var graph =  Fluently.CreateUndirectedGraph();
            
            foreach (var item in typeof(NodeShape).GetFields(BindingFlags.Public | BindingFlags.Static).Where(x => typeof(NodeShape).IsAssignableFrom(x.FieldType)))
            {
                var shape = (NodeShape) item.GetValue(null);
                graph.Nodes.Add(x => x.WithName(item.Name).WithShape(shape));
            }

            return graph;
        }

        #endregion
    }
}