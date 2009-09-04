/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Drawing;
using System.IO;
using FluentDot.Execution;
using FluentDot.Expressions.Graphs;

namespace FluentDot.Samples.Core.Demos
{
    /// <summary>
    /// A base class for demos implementing <see cref="IGraphDemo"/>.
    /// </summary>
    public abstract class AbstractGraphDemo : IGraphDemo {

        #region IGraphDemo Members

        /// <summary>
        /// Draws the graph.
        /// </summary>
        /// <param name="dot"></param>
        /// <returns>An image.</returns>
        public Image DrawGraph(out string dot)
        {
            string fileName = Path.GetTempFileName();
            var graph = CreateGraph();
            dot = graph.GenerateDot();
            graph.Save(x => x.ToFile(fileName).UsingFormat(OutputFormat.PNG));

            var ms = new MemoryStream(File.ReadAllBytes(fileName));
            File.Delete(fileName);
            return Image.FromStream(ms);
        }

        /// <summary>
        /// Gets or sets the friendly name of this demo.
        /// </summary>
        /// <value>The friendly name of the demo.</value>
        public abstract string FriendlyName { get;}

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public abstract string Description { get; }

        /// <summary>
        /// Gets or sets the type of demo.
        /// </summary>
        /// <value>The type of demo.</value>
        public abstract DemoType Type { get; }

        #endregion

        #region Protected Members

        /// <summary>
        /// Produces the dot for the specified demo.
        /// </summary>
        /// <returns>DOT.</returns>
        protected abstract IGraphExpression CreateGraph();

        #endregion
    }
}