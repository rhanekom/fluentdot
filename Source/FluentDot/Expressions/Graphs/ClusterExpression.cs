/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// A concrete implementation of a <see cref="IClusterExpression"/>.
    /// </summary>
    public class ClusterExpression : IClusterExpression {
        
        #region Globals

        private readonly Cluster cluster;
        private readonly IGraph graph;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterExpression"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public ClusterExpression(IGraph graph)
        {
            cluster = new Cluster(graph);
            this.graph = graph;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the cluster.
        /// </summary>
        /// <value>The cluster.</value>
        public Cluster Cluster {
            get { return cluster; }
        }

        #endregion

        #region IClusterExpression Memebers

        /// <summary>
        /// Sets the name of the cluster.
        /// </summary>
        /// <param name="clusterName">Name of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithName(string clusterName)
        {
            cluster.Name = clusterName;
            return this;
        }

        /// <summary>
        /// Sets the background color of the cluster.
        /// </summary>
        /// <param name="color">The color to set the background to.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithBackgroundColor(Color color)
        {
            cluster.Attributes.AddAttribute(new BackgroundColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Specifies the color of the cluster.
        /// </summary>
        /// <param name="color">The color of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithColor(Color color)
        {
            cluster.Attributes.AddAttribute(new ColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Sets the fill color of the cluster.
        /// </summary>
        /// <param name="color">The color to set the fill color to.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithFillColor(Color color)
        {
            cluster.Attributes.AddAttribute(new FillColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Sets the cluster url.
        /// </summary>
        /// <param name="url">The URL that should be set on the cluster.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithUrl(string url)
        {
            cluster.Attributes.AddAttribute(new URLAttribute(url));
            return this;
        }

        /// <summary>
        /// Sets the font name that is used to label the cluster.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithFontName(string fontName) {
            cluster.Attributes.AddAttribute(new FontNameAttribute(fontName));
            return this;
        }

        /// <summary>
        /// Sets the font size that is used to label the cluster.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithFontSize(double fontSize) {
            cluster.Attributes.AddAttribute(new FontSizeAttribute(fontSize));
            return this;
        }

        /// <summary>
        /// Sets the font color that is used to label the cluster.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithFontColor(Color fontColor) {
            cluster.Attributes.AddAttribute(new FontColorAttribute(fontColor));
            return this;
        }

        /// <summary>
        /// Sets the label displayed on the cluster.
        /// </summary>
        /// <param name="label">The label of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithLabel(string label) {
            cluster.Attributes.AddAttribute(new LabelAttribute(label));
            return this;
        }

        /// <summary>
        /// Sets the justification of the cluster label.
        /// </summary>
        /// <param name="justification">The justification of the cluster label.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithLabelJustification(Justification justification) {
            cluster.Attributes.AddAttribute(new LabelJustificationAttribute(justification));
            return this;
        }

        /// <summary>
        /// Sets the label location (top or bottom) of the cluster label.
        /// </summary>
        /// <param name="location">The location of the cluster label.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithLabelLocation(Location location) {
            cluster.Attributes.AddAttribute(new LabelLocationAttribute(location));
            return this;
        }

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the cluster.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression DoNotJustify() {
            cluster.Attributes.AddAttribute(new NoJustifyAttribute(true));
            return this;
        }

        /// <summary>
        /// Applies the specified style to the cluster.
        /// </summary>
        /// <param name="style">The style to apply to the cluster.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithStyle(ClusterStyle style)
        {
            cluster.Attributes.AddAttribute(new StyleAttribute(style));
            return this;
        }

        /// <summary>
        /// Sets the pen color used to draw the cluster.
        /// </summary>
        /// <param name="penColor">The pen color used to draw the cluster.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithPenColor(Color penColor)
        {
            cluster.Attributes.AddAttribute(new PenColorAttribute(penColor));
            return this;
        }

        /// <summary>
        /// Sets the width of the pen color used to draw the bounding box of the cluster.
        /// </summary>
        /// <param name="penWidth">Width of the pen used to draw the bounding box of the cluster.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithPenWidth(double penWidth)
        {
            cluster.Attributes.AddAttribute(new PenWidthAttribute(penWidth));
            return this;
        }

        /// <summary>
        /// Set number of peripheries used in the cluster boundaries.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The current expression instance.</returns>
        public IClusterExpression WithPeripheries(int value)
        {
            if (value > 1) {
                throw new ArgumentOutOfRangeException("value", "Peripheries for clusters can not be greater than 1.");
            }

            cluster.Attributes.AddAttribute(new PeripheriesAttribute(value));
            return this;
        }

        /// <summary>
        /// Edits the node collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the node collection.</value>
        public INodeCollectionModifiersExpression<IClusterExpression> Nodes {
            get { return new NodeCollectionModifiersExpression<IClusterExpression>(cluster, this); }
        }

        /// <summary>
        /// Edits the edge collection for this cluster.
        /// </summary>
        /// <value>The expression for acting upon the edge collection.</value>
        public IEdgeCollectionModifiersExpression<IClusterExpression> Edges {
            get { return new EdgeCollectionModifiersExpression<IClusterExpression>(cluster, this); }
        }

        #endregion
    }
}