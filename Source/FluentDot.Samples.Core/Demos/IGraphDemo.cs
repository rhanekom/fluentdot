/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;

namespace FluentDot.Samples.Core.Demos
{
    /// <summary>
    /// A simple interface for a graph demo.
    /// </summary>
    public interface IGraphDemo {

        /// <summary>
        /// Draws the graph.
        /// </summary>
        /// <returns>An image.</returns>
        Image DrawGraph(out string dot);

        /// <summary>
        /// Gets or sets the name of the friendly.
        /// </summary>
        /// <value>The name of the friendly.</value>
        string FriendlyName { get; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        /// <value>The rank.</value>
        DemoType Type { get; }
    }
}