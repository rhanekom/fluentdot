/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes;
using FluentDot.Attributes.Edges;
using FluentDot.Attributes.Shared;
using FluentDot.Entities.Edges;

namespace FluentDot.Expressions.Edges
{
    /// <summary>
    /// A concrete implementation of an <see cref="IEdgeExpression"/>.
    /// </summary>
    public class EdgeExpression : IEdgeExpression {
        
        #region Globals

        private readonly IEdge edge;
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeExpression"/> class.
        /// </summary>
        /// <param name="edge">The edge.</param>
        public EdgeExpression(IEdge edge)
        {
            this.edge = edge;
        }

        #endregion

        #region IEdgeExpression Members

        /// <summary>
        /// Specifies the label to apply to the edge.
        /// </summary>
        /// <param name="label">The label to apply to the edge.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithLabel(string label) {
            edge.Attributes.AddAttribute(new LabelAttribute(label));
            return this;
        }

        /// <summary>
        /// Sets the tag on the edge.
        /// </summary>
        /// <typeparam name="T">The type of the tag.</typeparam>
        /// <param name="tag">The tag to set on the edge.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithTag<T>(T tag)
        {
            edge.Tag = tag;
            return this;
        }

        /// <summary>
        /// Sets the edge url.
        /// </summary>
        /// <param name="url">The URL that should be set on the edge.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithUrl(string url)
        {
            edge.Attributes.AddAttribute(new URLAttribute(url));
            return this;
        }

        /// <summary>
        /// Specifies the color of the edge.
        /// </summary>
        /// <param name="color">The color of the edge.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithColor(Color color)
        {
            edge.Attributes.AddAttribute(new ColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Applies the specified style to the edge.
        /// </summary>
        /// <param name="style">The style to apply to the edge.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithStyle(EdgeStyle style)
        {
            edge.Attributes.AddAttribute(new StyleAttribute(style));
            return this;
        }

        /// <summary>
        /// Do not use this edge in ranking the nodes.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression DoNotConstrainNodes()
        {
            edge.Attributes.AddAttribute(new ConstraintAttribute(false));
            return this;
        }

        /// <summary>
        /// Sets the label that that will be shown close to the tail of the edge.
        /// </summary>
        /// <param name="label">The label to set.</param>
        /// <returns>the current expression instance.</returns>
        public IEdgeExpression WithTailLabel(string label)
        {
            edge.Attributes.AddAttribute(new TailLabelAttribute(label));
            return this;
        }

        /// <summary>
        /// Sets the label that will be shown close to the head of the edge.
        /// </summary>
        /// <param name="label">The label to set.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithHeadLabel(string label)
        {
            edge.Attributes.AddAttribute(new HeadLabelAttribute(label));
            return this;
        }

        /// <summary>
        /// Specifies the angle that the label should take.
        /// </summary>
        /// <param name="angle">The angle to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithLabelAngle(double angle)
        {
            edge.Attributes.AddAttribute(new LabelAngleAttribute(angle));
            return this;
        }

        /// <summary>
        /// Specifies the distance the label should be from the edge.
        /// </summary>
        /// <param name="distance">The distance to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithLabelDistance(double distance)
        {
            edge.Attributes.AddAttribute(new LabelDistanceAttribute(distance));
            return this;
        }

        /// <summary>
        /// Specifies that the lable should float - specifically, that the label is allowed to be on top of other edges.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression FloatLabel()
        {
            edge.Attributes.AddAttribute(new LabelFloatAttribute(true));
            return this;
        }

        /// <summary>
        /// Specifies the minimum edge length (the rank difference between the head and tail of the edge).
        /// </summary>
        /// <param name="rank">The rank.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithMinimumLength(int rank)
        {
            edge.Attributes.AddAttribute(new MinimumLengthAttribute(rank));
            return this;
        }

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the edge.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression DoNotJustify()
        {
            edge.Attributes.AddAttribute(new NoJustifyAttribute(true));
            return this;
        }

        /// <summary>
        /// Specifies a custom attribute that should be applied to the edge.
        /// </summary>
        /// <param name="attribute">The attribute to apply to the edge.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithCustomAttribute(IDotAttribute attribute)
        {
            edge.Attributes.AddAttribute(attribute);
            return this;
        }

        /// <summary>
        /// Specifies the type of arrow to use for the head of the arrow.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithArrowHead(CompositeArrowShape arrowShape) {
            edge.Attributes.AddAttribute(new ArrowHeadAttribute(arrowShape));
            return this;
        }

        /// <summary>
        /// Specifies the type of arrow to use for the tail of the arrow.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithArrowTail(ArrowShape arrowShape) {
            edge.Attributes.AddAttribute(new ArrowTailAttribute(arrowShape));
            return this;
        }

        /// <summary>
        /// Specifies the type of arrow to use for the tail of the arrow.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithArrowTail(CompositeArrowShape arrowShape) {
            edge.Attributes.AddAttribute(new ArrowTailAttribute(arrowShape));
            return this;
        }

        /// <summary>
        /// Specifies the font name of the arrow tail and head labels.
        /// </summary>
        /// <param name="fontName">Name of the font to apply to the arrow tail and head labels.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithLabelFontName(string fontName)
        {
            edge.Attributes.AddAttribute(new LabelFontNameAttribute(fontName));
            return this;
        }

        /// <summary>
        /// Specifies the font color of the arrow tail and head labels.
        /// </summary>
        /// <param name="color">The color to apply to the arrow tail and head labels.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithLabelFontColor(Color color)
        {
            edge.Attributes.AddAttribute(new LabelFontColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Specifies the font name of the arrow tail and head labels.
        /// </summary>
        /// <param name="points">The size of the font in points.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithLabelFontSize(double points)
        {
            edge.Attributes.AddAttribute(new LabelFontSizeAttribute(points));
            return this;
        }

        /// <summary>
        /// Specifies the scale of the arrow.
        /// </summary>
        /// <param name="scale">The scale (size) of the arrow.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithArrowSize(double scale) {
            edge.Attributes.AddAttribute(new ArrowSizeAttribute(scale));
            return this;
        }

        /// <summary>
        /// Specifies the direction of the arrow.
        /// </summary>
        /// <param name="direction">The direction of the arrow.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithArrowDirection(ArrowDirection direction) {
            edge.Attributes.AddAttribute(new ArrowDirectionAttribute(direction));
            return this;
        }

        /// <summary>
        /// Sets the font name that is used to label the edge.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithFontName(string fontName) {
            edge.Attributes.AddAttribute(new FontNameAttribute(fontName));
            return this;
        }

        /// <summary>
        /// Sets the font size that is used to label the edge.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithFontSize(double fontSize) {
            edge.Attributes.AddAttribute(new FontSizeAttribute(fontSize));
            return this;
        }

        /// <summary>
        /// Sets the font color that is used to label the edge.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithFontColor(Color fontColor) {
            edge.Attributes.AddAttribute(new FontColorAttribute(fontColor));
            return this;
        }

        /// <summary>
        /// Specifies the type of arrow to use.
        /// </summary>
        /// <param name="arrowShape">The arrow type to use.</param>
        /// <returns>The current expression instance.</returns>
        public IEdgeExpression WithArrowHead(ArrowShape arrowShape) {
            edge.Attributes.AddAttribute(new ArrowHeadAttribute(arrowShape));
            return this;
        }

        #endregion
    }
}