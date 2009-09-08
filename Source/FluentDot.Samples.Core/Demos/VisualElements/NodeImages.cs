/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Graphs;
using System.IO;
using FluentDot.Samples.Core.Images;

namespace FluentDot.Samples.Core.Demos.VisualElements
{
    /// <summary>
    /// A simple demo of edge constraints.
    /// </summary>
    public class NodeImages : AbstractGraphDemo {

        #region Globals

        private string fullMoon;
        private string science;

        #endregion

        #region AbstractGraphDemo Members

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public override string FriendlyName {
            get { return "Node Images"; }
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public override string Description {
            get { return "A demo of how nodes can contain images."; }
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
        protected override IGraphExpression CreateGraph() {
            CleanUp();
            SaveImages();

            return Fluently.CreateDirectedGraph()
                .Nodes.Add(nodes =>
                               {
                                   nodes.WithName("a").ContainsImage(fullMoon);
                                   nodes.WithName("b").ContainsImage(science);
                                   nodes.WithName("c").ContainsImage(fullMoon).WithHeight(1.5).WithWidth(1.5);
                                   nodes.WithName("d").ContainsImage(science);
                                   nodes.WithName("e").ContainsScaledImage(fullMoon).WithHeight(1.5).WithWidth(1.5).WithLabel("Scaled Image");
                                   nodes.WithName("f").ContainsScaledImage(science).WithHeight(1.8).WithWidth(1.5).WithLabel("Scaled Image");
                                   nodes.WithName("g").ContainsImage(fullMoon);
                                   nodes.WithName("h").ContainsImage(science);
                               })
                .Edges.Add(edges =>
                               {
                                   edges.From.NodeWithName("a").To.NodeWithName("b");
                                   edges.From.NodeWithName("a").To.NodeWithName("c");
                                   edges.From.NodeWithName("b").To.NodeWithName("c");
                                   edges.From.NodeWithName("c").To.NodeWithName("d");
                                   edges.From.NodeWithName("b").To.NodeWithName("e");
                                   edges.From.NodeWithName("e").To.NodeWithName("f");
                                   edges.From.NodeWithName("e").To.NodeWithName("g");
                                   edges.From.NodeWithName("g").To.NodeWithName("h");
                               }
                );
        }

        public override void CleanUp() {
            DeleteTemporaryFile(fullMoon);
            DeleteTemporaryFile(science);
        }

        #endregion

        #region Private Members

        private void SaveImages() {
            fullMoon = Path.GetTempFileName();
            science = Path.GetTempFileName();

            using (var bitmap = ImageResources.FullMoon) {
                bitmap.Save(fullMoon);
            }

            using (var bitmap = ImageResources.Science) {
                bitmap.Save(science);
            }
        }

        private static void DeleteTemporaryFile(string fileName) {
            if (fileName != null) {
                if (File.Exists(fileName)) {
                    File.Delete(fileName);
                }
            }
        }

        #endregion
    }
}