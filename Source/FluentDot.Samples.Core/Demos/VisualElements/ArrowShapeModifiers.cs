/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Linq;
using System.Reflection;
using FluentDot.Attributes.Edges;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A demo showing off the different kinds of arrowshapes.
    /// </summary>
    public class ArrowShapeModifiers : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        public override string FriendlyName {
            get { return "DOT Arrow Modifiers"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of the modifiers that DOT can apply to arrow shapes."; }
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

            foreach (ArrowShapeModifier modifier in Enum.GetValues(typeof(ArrowShapeModifier)))
            {
                foreach (var item in typeof (ArrowShape).GetFields(BindingFlags.Public | BindingFlags.Static).Where(x => typeof (ArrowShape).IsAssignableFrom(x.FieldType)))
                {
                    var shape = (ArrowShape) item.GetValue(null);

                    if ((modifier == ArrowShapeModifier.RightClip) || (modifier == ArrowShapeModifier.LeftClip))
                    {
                        if (!shape.LRModifierAllowed)
                        {
                            continue;
                        }
                    } 
                    else if (modifier == ArrowShapeModifier.Open)
                    {
                        if (!shape.OModifierAllowed)
                        {
                            continue;
                        }
                    } 
                    else if (modifier == ArrowShapeModifier.None)
                    {
                        continue;
                    }

                    shape = shape.Modify(modifier);

                    graph.Edges.Add(
                        x => x.FromNodeWithName(a.ToString())
                                 .ToNodeWithName(b.ToString())
                                 .WithArrowHead(shape)
                                 .WithArrowTail(shape)
                                 .WithLabel(item.Name + " - " + modifier.ToString()));

                    

                    a += 2;
                    b += 2;
                }
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