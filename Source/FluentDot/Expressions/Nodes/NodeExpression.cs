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
using FluentDot.Entities.Graphs;

namespace FluentDot.Expressions.Nodes
{
    /// <summary>
    /// A concrete implementation of a <see cref="INodeExpression"/>.
    /// </summary>
    public class NodeExpression : INodeExpression {
        
        #region Globals

        private readonly IGraphNode node;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeExpression"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public NodeExpression(IGraphNode node)
        {
            this.node = node;
        }

        #endregion

        #region INodeExpression Members

        /// <summary>
        /// Specifies the label to apply to the node.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithLabel(string label) {
            node.Attributes.AddAttribute(new LabelAttribute(label));
            return this;
        }

        /// <summary>
        /// Sets the tag on the node.
        /// </summary>
        /// <typeparam name="T">The type of the tag.</typeparam>
        /// <param name="tag">The tag to set on the node.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithTag<T>(T tag)
        {
            node.Tag = tag;
            return this;
        }

        /// <summary>
        /// Sets the node color.
        /// </summary>
        /// <param name="color">The color of the node.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithColor(Color color)
        {
            node.Attributes.AddAttribute(new ColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Sets the fill color of the node. Style must be equal to "filled" for this to take effect.
        /// </summary>
        /// <param name="color">The color to set the fill color to.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithFillColor(Color color)
        {
            node.Attributes.AddAttribute(new FillColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Sets the font name that is used to label the node.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithFontName(string fontName) {
            node.Attributes.AddAttribute(new FontNameAttribute(fontName));
            return this;
        }

        /// <summary>
        /// Sets the font size that is used to label the node.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithFontSize(double fontSize) {
            node.Attributes.AddAttribute(new FontSizeAttribute(fontSize));
            return this;
        }

        /// <summary>
        /// Sets the font color that is used to label the node.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithFontColor(Color fontColor) {
            node.Attributes.AddAttribute(new FontColorAttribute(fontColor));
            return this;
        }

        /// <summary>
        /// Sets the height of the node.
        /// </summary>
        /// <param name="height">The height of the node.</param>
        /// <returns>the current</returns>
        public INodeExpression WithHeight(double height) {
            node.Attributes.AddAttribute(new HeightAttribute(height));
            return this;
        }

        /// <summary>
        /// Set the width of the node.
        /// </summary>
        /// <param name="width">The width of the node.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithWidth(double width) {
            node.Attributes.AddAttribute(new WidthAttribute(width));
            return this;
        }

        /// <summary>
        /// Sets the node sizing mode as fixed.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public INodeExpression IsFixedSize() {
            node.Attributes.AddAttribute(new FixedSizeAttribute(true));
            return this;
        }

        /// <summary>
        /// Specifies the space left around the label of the node.
        /// </summary>
        /// <param name="x">The x margin.</param>
        /// <param name="y">The y margin.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithLabelMargin(float x, float y)
        {
            node.Attributes.AddAttribute(new MarginAttribute(x, y));
            return this;
        }

        /// <summary>
        /// Sets the drawing style of the node.
        /// </summary>
        /// <param name="style">The style the node should be drawn in.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithStyle(NodeStyle style)
        {
            node.Attributes.AddAttribute(new StyleAttribute(style));
            return this;
        }

        /// <summary>
        /// Sets the node url.
        /// </summary>
        /// <param name="url">The URL that should be set on the node.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithUrl(string url)
        {
            node.Attributes.AddAttribute(new URLAttribute(url));
            return this;
        }

        /// <summary>
        /// Sets the shape that the node should be.
        /// </summary>
        /// <param name="shape">The shape of the node.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithShape(NodeShape shape)
        {
            node.Attributes.AddAttribute(new NodeShapeAttribute(shape));
            return this;
        }

        /// <summary>
        /// Sets the group on the node.  If the end points of an edge belong to the same group, parameters are set to avoid crossings and keep the edges straight.
        /// </summary>
        /// <param name="groupName">Name of the group that this node belongs to.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression BelongsToGroup(string groupName)
        {
            node.Attributes.AddAttribute(new GroupAttribute(groupName));
            return this;
        }

        /// <summary>
        /// Specifies a custom attribute that should be applied to the node.
        /// </summary>
        /// <param name="attribute">The attribute to apply to the node.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithCustomAttribute(IDotAttribute attribute)
        {
            node.Attributes.AddAttribute(attribute);
            return this;
        }

        /// <summary>
        /// Specifies the vertical location of the node label.
        /// </summary>
        /// <param name="location">The location of the node label.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithLabelLocation(Location location)
        {
            node.Attributes.AddAttribute(new LabelLocationAttribute(location));
            return this;
        }

        /// <summary>
        /// Sets the image that the node should contain.
        /// </summary>
        /// <param name="pathToImage">The path to the image.</param>
        /// <returns>The current expression instance</returns>
        public INodeExpression ContainsImage(string pathToImage)
        {
            node.Attributes.AddAttribute(new ImageAttribute(pathToImage));
            return this;
        }

        /// <summary>
        /// Sets the scaled image that the node should contain.
        /// </summary>
        /// <param name="pathToImage">The path to the image.</param>
        /// <returns>The current expression instance</returns>
        public INodeExpression ContainsScaledImage(string pathToImage)
        {
            ContainsImage(pathToImage);
            node.Attributes.AddAttribute(new ImageScaleAttribute(true));
            return this;
        }

        /// <summary>
        /// Specifies the node orientation for nodes with polygon shapes.
        /// </summary>
        /// <param name="degrees">The degrees to which the node should be orientated on.</param>
        /// <returns>The current expression instance.</returns>
        public INodeExpression WithOrientation(int degrees)
        {
            node.Attributes.AddAttribute(new OrientationAttribute(degrees));
            return this;
        }

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the node.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public INodeExpression DoNotJustify()
        {
            node.Attributes.AddAttribute(new NoJustifyAttribute(true));
            return this;
        }

        #endregion
    }
}