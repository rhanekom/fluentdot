﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Expressions.Graphs;
using FluentDot.Attributes.Nodes;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo for the setting node and edge defaults in a graph.
    /// </summary>
    public class GraphDefaults : AbstractGraphDemo {

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
                .TheDefaults.ForEdges.Are(x => x.WithLabel("Default Color Blue").WithColor(Color.Blue))
                .TheDefaults.ForNodes.Are(x => x.WithShape(NodeShape.Diamond).WithColor(Color.Green).WithLabel("Green Diamond"))
                .Nodes.Add(x => 
                    x.WithName("c")
                     .WithShape(NodeShape.DoubleCircle)
                     .WithColor(Color.DarkMagenta)
                     .WithLabel("Override of Shape and Color"))
                .Edges.Add(x =>
                               {
                                   x.FromNodeWithName("a").ToNodeWithName("b");
                                   x.FromNodeWithName("a").ToNodeWithName("c").WithColor(Color.Red).WithLabel("Override of Red Color");
                                   x.FromNodeWithName("c").ToNodeWithName("d");
                                   x.FromNodeWithName("b").ToNodeWithName("d");
                               }
                );
            #endregion
        }

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName {
            get { return "Graph Defaults"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "An illustration of how one can apply defaults to edges and nodes in a graph."; }
        }

        #endregion
    }
}