/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// The root expression for building clusters.
    /// </summary>
    public interface IClusterExpression {

        /// <summary>
        /// Sets the name of the cluster.
        /// </summary>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithName(string clusterName);

        /// <summary>
        /// Sets the background color of the cluster.
        /// </summary>
        /// <param name="color">The color to set the background to.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithBackgroundColor(Color color);

        /// <summary>
        /// Specifies the color of the cluster.
        /// </summary>
        /// <param name="color">The color of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithColor(Color color);

        /// <summary>
        /// Sets the fill color of the cluster.
        /// </summary>
        /// <param name="color">The color to set the fill color to.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithFillColor(Color color);
        
        /// <summary>
        /// Sets the cluster url.
        /// </summary>
        /// <param name="url">The URL that should be set on the cluster.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithUrl(string url);

        /// <summary>
        /// Sets the font name that is used to label the cluster.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithFontName(string fontName);

        /// <summary>
        /// Sets the font size that is used to label the cluster.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithFontSize(double fontSize);

        /// <summary>
        /// Sets the font color that is used to label the cluster.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithFontColor(Color fontColor);

        /// <summary>
        /// Sets the label displayed on the cluster.
        /// </summary>
        /// <param name="label">The label of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithLabel(string label);

        /// <summary>
        /// Sets the justification of the cluster label.
        /// </summary>
        /// <param name="justification">The justification of the cluster label.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithLabelJustification(Justification justification);

        /// <summary>
        /// Sets the label location (top or bottom) of the cluster label.
        /// </summary>
        /// <param name="location">The location of the cluster label.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithLabelLocation(Location location);

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the cluster.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IClusterExpression DoNotJustify();

        /// <summary>
        /// Applies the specified style to the cluster.
        /// </summary>
        /// <param name="style">The style to apply to the cluster.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithStyle(ClusterStyle style);

        /// <summary>
        /// Sets the pen color used to draw the bounding box of the cluster.
        /// </summary>
        /// <param name="penColor">The pen color used to draw the bounding box of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithPenColor(Color penColor);

        /// <summary>
        /// Sets the width of the pen color used to draw the bounding box of the cluster.
        /// </summary>
        /// <param name="penWidth">Width of the pen used to draw the bounding box of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        IClusterExpression WithPenWidth(double penWidth);

        /// <summary>
        /// Edits the node collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the node collection.</value>
        INodeCollectionModifiersExpression<IClusterExpression> Nodes { get; }

        /// <summary>
        /// Edits the edge collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the edge collection.</value>
        IEdgeCollectionModifiersExpression<IClusterExpression> Edges { get; }
    }
}