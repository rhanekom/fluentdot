/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Edges;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    public class ArrowDirections : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName {
            get { return "Arrow Directions"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "Demo of the different arrow directions that dot supports."; }
        }

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
                .Edges.Add(edges =>
                               {
                                   edges.FromNodeWithName("a").ToNodeWithName("b")
                                       .WithArrowDirection(ArrowDirection.Back)
                                       .WithLabel("Back");

                                   edges.FromNodeWithName("c").ToNodeWithName("d")
                                       .WithArrowDirection(ArrowDirection.Both)
                                       .WithLabel("Both");

                                   edges.FromNodeWithName("e").ToNodeWithName("f")
                                       .WithArrowDirection(ArrowDirection.Forward)
                                       .WithLabel("Forward");

                                   edges.FromNodeWithName("g").ToNodeWithName("h")
                                       .WithArrowDirection(ArrowDirection.None)
                                       .WithLabel("None");
                               });
            #endregion
        }

        #endregion
    }
}