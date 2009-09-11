/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos.Layout
{
    /// <summary>
    /// A demo of how records can be used to build composite nodes.
    /// </summary>
    public class Records : AbstractGraphDemo {

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Records"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of how records can be used to build composite nodes."; }
        }

        /// <summary>
        /// Gets or sets the type of demo.
        /// </summary>
        /// <value>The type of demo.</value>
        public override DemoType Type {
            get { return DemoType.Layout; }
        }

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected override IGraphExpression CreateGraph()
        {
            #region ExportCode
            return Fluently.CreateDirectedGraph()
                .Nodes.AddRecord(record =>
                                     {
                                         record.WithName("struct1")
                                             .WithElement("f0", x => x.WithLabel("left"))
                                             .WithElement("f1", x => x.WithLabel("mid dle"))
                                             .WithElement("f2", x => x.WithLabel("right"));

                                         record.WithName("struct2")
                                             .WithElement("f0", x => x.WithLabel("one"))
                                             .WithElement("f1", x => x.WithLabel("two"));

                                         record.WithName("struct3")
                                             .WithElement("f0", x => x.WithLabel(@"hello\nworld"))
                                             .WithGroup(g1 => g1
                                                                  .WithElement("b")
                                                                  .WithGroup(g2 => g2
                                                                                       .WithElement("c")
                                                                                       .WithElement("here", x => x.WithLabel("d"))
                                                                                       .WithElement("e"),
                                                                             g2 => g2.IsInverted())
                                                                  .WithElement("f"), g1 => g1.IsInverted())
                                             .WithElement("g")
                                             .WithElement("h");
                                     }
                )
                .Edges.Add(edges =>
                               {
                                   edges.From.RecordWithName("struct1", "f1").To.RecordWithName("struct2", "f0");
                                   edges.From.RecordWithName("struct1", "f2").To.RecordWithName("struct3", "here");
                               });
            #endregion
        }

        #endregion
    }
}