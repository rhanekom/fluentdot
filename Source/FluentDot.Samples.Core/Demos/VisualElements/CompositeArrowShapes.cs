/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentDot.Attributes.Edges;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo showing off the different kinds of arrowshapes.
    /// </summary>
    public class CompositeArrowShapes : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName {
            get { return "DOT Composite Arrow Shapes"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of applying more than one arrow shape to an edge."; }
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

            var arrowShapes = typeof(ArrowShape)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => typeof(ArrowShape).IsAssignableFrom(x.FieldType))
                .Select(x => (ArrowShape) x.GetValue(null))
                .ToArray();

            var random = new Random((int)(DateTime.Now.Ticks % Int32.MaxValue));

            for (int i = 0; i< 10; i++)
            {
                const int numberOfArrowShapes = 2;

                var chosenArrowShapes = new List<ArrowShape>();

                for (int j = 0; j< numberOfArrowShapes; j++)
                {
                    var chosenShape = arrowShapes[random.Next(arrowShapes.Length)];

                    if ((chosenShape == ArrowShape.None) || (chosenArrowShapes.Contains(chosenShape))) {
                        j--;
                        continue;
                    }
                    
                    chosenArrowShapes.Add(chosenShape);
                }

                var shape = new CompositeArrowShape(chosenArrowShapes.ToArray());

                graph.Edges.Add(x => x.From.NodeWithName(a.ToString()).To.NodeWithName(b.ToString())
                                        .WithArrowHead(shape)
                                        .WithLabel(shape.ToDot()));

                a+=2;
                b+=2;
            }

            return graph;
            #endregion
        }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
        public override DemoType Type {
            get { return DemoType.VisualElements; }
        }

        #endregion
    }
}