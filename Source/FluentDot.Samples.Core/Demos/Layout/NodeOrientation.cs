/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Nodes;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout
{
    /// <summary>
    /// A demonstration of node orientation.
    /// </summary>
    public class NodeOrientation : AbstractGraphDemo
    {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName
        {
            get { return "Node Orientation"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description
        {
            get { return "A demo of the node orientation."; }
        }

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected override IGraphExpression CreateGraph()
        {
            #region ExportCode
            var graph = Fluently.CreateDirectedGraph();
            
            graph.Nodes.Add(x => x.WithName("D0").WithOrientation(0));
            
            for (int i = 30; i < 360; i += 30)
            {
                graph.Nodes.Add(x => x.WithName("D" + i).WithOrientation(i).WithShape(NodeShape.Polygon));
                graph.Edges.Add(edge => edge.From.NodeWithName("D" + (i - 30).ToString()).To.NodeWithName("D" + i));
            }

            return graph;
            #endregion
        }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
        public override DemoType Type
        {
            get { return DemoType.Layout; }
        }

        #endregion
    }
}