/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes;
using FluentDot.Attributes.Edges;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// An expression for modifying an edge instance.
    /// </summary>
    public interface IEdgeExpression {

        /// <summary>
        /// Specifies the label to apply to the edge.
        /// </summary>
        /// <param name="label">The label to apply to the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithLabel(string label);

        /// <summary>
        /// Sets the tag on the edge.
        /// </summary>
        /// <typeparam name="T">The type of the tag.</typeparam>
        /// <param name="tag">The tag to set on the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithTag<T>(T tag);

        /// <summary>
        /// Sets the edge url.
        /// </summary>
        /// <param name="url">The URL that should be set on the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithURL(string url);

        /// <summary>
        /// Specifies the color of the edge.
        /// </summary>
        /// <param name="color">The color of the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithColor(Color color);

        /// <summary>
        /// Applies the specified style to the edge.
        /// </summary>
        /// <param name="style">The style to apply to the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithStyle(EdgeStyle style);

        /// <summary>
        /// Specifies the type of arrow to use for the head of the arrow.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithArrowHead(ArrowShape arrowShape);

        /// <summary>
        /// Specifies the type of arrow to use for the head of the arrow.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithArrowHead(CompositeArrowShape arrowShape);

        /// <summary>
        /// Specifies the type of arrow to use for the tail of the arrow.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithArrowTail(ArrowShape arrowShape);

        /// <summary>
        /// Specifies the type of arrow to use for the tail of the arrow.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithArrowTail(CompositeArrowShape arrowShape);

        /// <summary>
        /// Specifies the font name of the arrow tail and head labels.
        /// </summary>
        /// <param name="fontName">Name of the font to apply to the arrow tail and head labels.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithLabelFontName(string fontName);

        /// <summary>
        /// Specifies the font color of the arrow tail and head labels.
        /// </summary>
        /// <param name="color">The color to apply to the arrow tail and head labels.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithLabelFontColor(Color color);

        /// <summary>
        /// Specifies the font name of the arrow tail and head labels.
        /// </summary>
        /// <param name="points">The size of the font in points.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithLabelFontSize(double points);

        /// <summary>
        /// Specifies the scale of the arrow.
        /// </summary>
        /// <param name="scale">The scale (size) of the arrow.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithArrowSize(double scale);

        /// <summary>
        /// Specifies the direction of the arrow.
        /// </summary>
        /// <param name="direction">The direction of the arrow.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithArrowDirection(ArrowDirection direction);

        /// <summary>
        /// Sets the font name that is used to label the edge.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithFontName(string fontName);

        /// <summary>
        /// Sets the font size that is used to label the edge.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithFontSize(double fontSize);

        /// <summary>
        /// Sets the font color that is used to label the edge.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithFontColor(Color fontColor);

        /// <summary>
        /// Do not use this edge in ranking the nodes.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression DoNotConstrainNodes();

        /// <summary>
        /// Sets the label that that will be shown close to the tail of the edge.
        /// </summary>
        /// <param name="label">The label to set.</param>
        /// <returns>the current expression instance.</returns>
        IEdgeExpression WithTailLabel(string label);

        /// <summary>
        /// Sets the label that will be shown close to the head of the edge.
        /// </summary>
        /// <param name="label">The label to set.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithHeadLabel(string label);

        /// <summary>
        /// Specifies the angle that the label should take.
        /// </summary>
        /// <param name="angle">The angle to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithLabelAngle(double angle);

        /// <summary>
        /// Specifies the distance the label should be from the edge.
        /// </summary>
        /// <param name="distance">The distance to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithLabelDistance(double distance);

        /// <summary>
        /// Specifies that the lable should float - specifically, that the label is allowed to be on top of other edges.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression FloatLabel();

        /// <summary>
        /// Specifies the minimum edge length (the rank difference between the head and tail of the edge).
        /// </summary>
        /// <param name="rank">The rank.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithMinimumLength(int rank);

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the edge.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression DoNotJustify();

        /// <summary>
        /// Sets the width of the pen color used to draw the edge.
        /// </summary>
        /// <param name="penWidth">Width of the pen used to draw the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithPenWidth(double penWidth);

        /// <summary>
        /// Sets the comment on the edge. 
        /// </summary>
        /// <param name="comment">The comment to include in the output.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithComment(string comment);

        /// <summary>
        /// Sets the edge labels to be decorated.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression Decorate();

        /// <summary>
        /// Specifies a tooltip to be applied to the edge.  Tooltips are only used if an url is specified for the edge.
        /// </summary>
        /// <param name="tooltip">The tooltip to use.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithEdgeTooltip(string tooltip);

        /// <summary>
        /// Specifies a url for the edge.
        /// </summary>
        /// <param name="url">The URL for the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithEdgeURL(string url);

        /// <summary>
        /// Specifies a url for the edge.
        /// </summary>
        /// <param name="url">The URL for the edge.</param>
        /// <param name="target">The target for the url to open in.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithEdgeURL(string url, string target);

        /// <summary>
        /// Specifies that the head of the edge should not be clipped at the boundary of the edge.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression DoNotClipHead();

        /// <summary>
        /// Specifies that the tail of the edge should not be clipped at the boundary of the edge.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression DoNotClipTail();
        
        /// <summary>
        /// Specifies a custom attribute that should be applied to the edge.
        /// </summary>
        /// <param name="attribute">The attribute to apply to the edge.</param>
        /// <returns>The current expression instance.</returns>
        IEdgeExpression WithCustomAttribute(IDotAttribute attribute);
    }
}