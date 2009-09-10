/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes;
using FluentDot.Attributes.Nodes;
using FluentDot.Attributes.Shared;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// An expression for adding nodes.
    /// </summary>
    public interface INodeExpression {
        
        /// <summary>
        /// Specifies the label to apply to the node.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithLabel(string label);

        /// <summary>
        /// Sets the tag on the node.
        /// </summary>
        /// <typeparam name="T">The type of the tag.</typeparam>
        /// <param name="tag">The tag to set on the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithTag<T>(T tag);

        /// <summary>
        /// Sets the node color.
        /// </summary>
        /// <param name="color">The color of the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithColor(Color color);
        
        /// <summary>
        /// Sets the fill color of the node. Style must be equal to "filled" for this to take effect.
        /// </summary>
        /// <param name="color">The color to set the fill color to.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithFillColor(Color color);

        /// <summary>
        /// Sets the font name that is used to label the node.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithFontName(string fontName);

        /// <summary>
        /// Sets the font size that is used to label the node.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithFontSize(double fontSize);

        /// <summary>
        /// Sets the font color that is used to label the node.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithFontColor(Color fontColor);

        /// <summary>
        /// Sets the height of the node.
        /// </summary>
        /// <param name="height">The height of the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithHeight(double height);

        /// <summary>
        /// Set the width of the node.
        /// </summary>
        /// <param name="width">The width of the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithWidth(double width);

        /// <summary>
        /// Sets the node sizing mode as fixed.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        INodeExpression IsFixedSize();

        /// <summary>
        /// Specifies the space left around the label of the node.
        /// </summary>
        /// <param name="x">The x margin.</param>
        /// <param name="y">The y margin.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithLabelMargin(float x, float y);

        /// <summary>
        /// Sets the drawing style of the node.
        /// </summary>
        /// <param name="style">The style the node should be drawn in.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithStyle(NodeStyle style);

        /// <summary>
        /// Sets the node url.
        /// </summary>
        /// <param name="url">The URL that should be set on the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithUrl(string url);

        /// <summary>
        /// Sets the shape that the node should be.
        /// </summary>
        /// <param name="shape">The shape of the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithShape(NodeShape shape);

        /// <summary>
        /// Sets the group on the node.  If the end points of an edge belong to the same group, parameters are set to avoid crossings and keep the edges straight.
        /// </summary>
        /// <param name="groupName">Name of the group that this node belongs to.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression BelongsToGroup(string groupName);

        /// <summary>
        /// Specifies a custom attribute that should be applied to the node.
        /// </summary>
        /// <param name="attribute">The attribute to apply to the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithCustomAttribute(IDotAttribute attribute);

        /// <summary>
        /// Specifies the vertical location of the node label.
        /// </summary>
        /// <param name="location">The location of the node label.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithLabelLocation(Location location);

        /// <summary>
        /// Sets the image that the node should contain.
        /// </summary>
        /// <param name="pathToImage">The path to the image.</param>
        /// <returns>The current expression instance</returns>
        INodeExpression ContainsImage(string pathToImage);

        /// <summary>
        /// Sets the scaled image that the node should contain.
        /// </summary>
        /// <param name="pathToImage">The path to the image.</param>
        /// <returns>The current expression instance</returns>
        INodeExpression ContainsScaledImage(string pathToImage);

        /// <summary>
        /// Specifies the node orientation.
        /// </summary>
        /// <param name="degrees">The degrees to which the node should be orientated on.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithOrientation(int degrees);

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the node.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        INodeExpression DoNotJustify();

        /// <summary>
        /// Sets the width of the pen color used to draw the node.
        /// </summary>
        /// <param name="penWidth">Width of the pen used to draw the node.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithPenWidth(double penWidth);

        /// <summary>
        /// Set number of peripheries used in the polygonal shapes.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithPeripheries(int value);

        /// <summary>
        /// Sets the distortion on the node.  Only used when the node shape is a polygon.
        /// </summary>
        /// <param name="value">The value to set the distortion to.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithDistortion(double value);

        /// <summary>
        /// Sets the comment on the node. 
        /// </summary>
        /// <param name="comment">The comment to include in the output.</param>
        /// <returns>The current expression instance.</returns>
        INodeExpression WithComment(string comment);
    }
}