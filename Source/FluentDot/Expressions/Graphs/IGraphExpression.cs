/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using FluentDot.Attributes;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Expressions.Conventions;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Execution;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// An expression for manipulating graph instances.
    /// </summary>
    public interface IGraphExpression {

        /// <summary>
        /// Generates the dot.
        /// </summary>
        /// <returns>A string with the DOT for the the current created graph.</returns>
        string GenerateDot();

        /// <summary>
        /// Instructs FluentDot to output to the specified filename.
        /// </summary>
        /// <param name="outputOptions">The output options.</param>
        void Save(Action<IOutputExpression> outputOptions);
        
        /// <summary>
        /// Sets the name of the graph.
        /// </summary>
        /// <param name="graphName">Name of the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithName(string graphName);

        /// <summary>
        /// Sets the url property on the graph.
        /// </summary>
        /// <param name="url">The URL to set on the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithURL(string url);

        /// <summary>
        /// Sets the background color of the graph.
        /// </summary>
        /// <param name="color">The color to set the background to.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithBackgroundColor(Color color);

        /// <summary>
        /// Sets the graph as concentrated - that is, to use edge concentrators.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IGraphExpression Concentrate();

        /// <summary>
        /// Centers the graph on the canvase.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IGraphExpression CenterOnCanvas();

        /// <summary>
        /// Sets the font name that is used to label the graph.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithFontName(string fontName);

        /// <summary>
        /// Sets the font size that is used to label the graph.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithFontSize(double fontSize);

        /// <summary>
        /// Sets the font color that is used to label the graph.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithFontColor(Color fontColor);

        /// <summary>
        /// Sets the label displayed on the graph.
        /// </summary>
        /// <param name="label">The label of the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithLabel(string label);

        /// <summary>
        /// Sets the justification of the graph label.
        /// </summary>
        /// <param name="justification">The justification of the graph label.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithLabelJustification(Justification justification);

        /// <summary>
        /// Sets the label location (top or bottom) of the graph label.
        /// </summary>
        /// <param name="location">The location of the graph label.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithLabelLocation(Location location);

        /// <summary>
        /// Writes the dot to the specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WriteDotTo(string fileName);

        /// <summary>
        /// Specifies a custom attribute that should be applied to the graph.
        /// </summary>
        /// <param name="attribute">The attribute to apply to the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithCustomAttribute(IDotAttribute attribute);

        /// <summary>
        /// Specifies the margin for the graph.
        /// </summary>
        /// <param name="x">The x margin.</param>
        /// <param name="y">The y margin.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithMargin(float x, float y);

        /// <summary>
        /// Specifies the edge ordering in the graph.
        /// </summary>
        /// <param name="ordering">The ordering of edges to apply to the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithEdgeOrdering(Ordering ordering);

        /// <summary>
        /// Renders the graph in landscape mode by rotating the graph 90 degrees.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IGraphExpression RenderLandscape();

        /// <summary>
        /// Sets the minimum node seperation, in inches.
        /// </summary>
        /// <param name="inches">The inches to set the minimum node seperation to.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithMinimumNodeSeperation(double inches);

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the graph.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        IGraphExpression DoNotJustify();

        /// <summary>
        /// Specifies the output order of thr graph.
        /// </summary>
        /// <param name="outputMode">The output mode the graph should use.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithOutputOrder(OutputMode outputMode);

        /// <summary>
        /// Specifies the padding, in inches, to extend the drawing area around the graph.
        /// </summary>
        /// <param name="x">The x padding.</param>
        /// <param name="y">The y padding.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithPadding(float x, float y);

        /// <summary>
        /// Sets the output of the graph to split among pages with the specified width and height.
        /// Pages will be output in the direction set by the page direction.
        /// </summary>
        /// <remarks>Only applicable for PostScript.</remarks>
        /// <param name="pageWidth">Width of the page.</param>
        /// <param name="pageHeight">Height of the page.</param>
        /// <returns>The current graph expression.</returns>
        IGraphExpression WithPageSize(float pageWidth, float pageHeight);

        /// <summary>
        /// If the graph is set as paged, this specifies the order in which pages are emitted.
        /// </summary>
        /// <param name="pageDirection">The page direction in which pages are emitted.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithPageDirection(PageDirection pageDirection);

        /// <summary>
        /// Sets the ratio behaviour of the graph.
        /// </summary>
        /// <param name="ratio">The ratio of the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithRatio(Ratio ratio);

        /// <summary>
        /// Sets the ratio value of the graph.
        /// </summary>
        /// <param name="value">The value of the ratio.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithRatio(double value);

        /// <summary>
        /// Sets the comment on the graph. 
        /// </summary>
        /// <param name="comment">The comment to include in the output.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithComment(string comment);

        /// <summary>
        /// Specifies the aspect of the graph.
        /// </summary>
        /// <param name="aspect">The aspect to apply to the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithAspect(double aspect);

        /// <summary>
        /// Specifies the aspect of the graph.
        /// </summary>
        /// <param name="aspect">The aspect to apply to the graph.</param>
        /// <param name="maximumPasses">The maximum number of passes dot should make over the graph.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithAspect(double aspect, int maximumPasses);

        /// <summary>
        /// Specifies the rank direction the graph should use in layout.
        /// </summary>
        /// <param name="rankDirection">The rank direction.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithRankDirection(RankDirection rankDirection);

        /// <summary>
        /// Sets the cluster rank mode on this graph.
        /// </summary>
        /// <param name="clusterMode">The cluster rank mode.</param>
        /// <returns>The current expression instance.</returns>
        IGraphExpression WithClusterRankMode(ClusterMode clusterMode);
        
        /// <summary>
        /// Sets the defaults entity values on this graph.
        /// </summary>
        /// <value>A defaults expression for setting default values for entities on the graph.</value>
        IDefaultsExpression TheDefaults { get; }

        /// <summary>
        /// Edits the conventions this graph should follow.
        /// </summary>
        /// <value>The conventions this graph should follow.</value>
        IConventionCollectionModifiersExpression<IGraphExpression> Conventions { get; }
            
        /// <summary>
        /// Edits the node collection for this graph.
        /// </summary>
        /// <value>The expression for acting upon the node collection.</value>
        INodeCollectionModifiersExpression<IGraphExpression> Nodes { get; }

        /// <summary>
        /// Edits the edge collection for this graph.
        /// </summary>
        /// <value>The expression for acting upon the edge collection.</value>
        IEdgeCollectionModifiersExpression<IGraphExpression> Edges { get; }

        /// <summary>
        /// Edits the sub graph collection for this graph.
        /// </summary>
        /// <value>The expression for acting upon the subgraph collection.</value>
        ISubGraphCollectionModifiersExpression<IGraphExpression> SubGraphs { get; }

        /// <summary>
        /// Edits the cluster collection for this graph.
        /// </summary>
        /// <value>The expression for acting upon the cluster collection.</value>
        IClusterCollectionModifiersExpression<IGraphExpression> Clusters { get; }
    }
}