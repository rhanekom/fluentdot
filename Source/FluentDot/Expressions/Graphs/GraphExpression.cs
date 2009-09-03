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
using FluentDot.Common;
using FluentDot.Entities.Graphs;
using FluentDot.Execution;
using FluentDot.Expressions.Conventions;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Execution;
using FluentDot.Expressions.Nodes;

namespace FluentDot.Expressions.Graphs
{
    /// <summary>
    /// A base class for graph expressions.
    /// </summary>
    public class GraphExpression<T> : IGraphExpression where T : IGraph {

        #region Globals

        private readonly T graph;
        private readonly IFileService fileService;
        private readonly IDotExecutor dotExecutor;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphExpression{T}"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public GraphExpression(T graph) : this(graph, new FileService(), new DotExecutor())
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GraphExpression{T}"/> class.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="fileService">The file service.</param>
        /// <param name="dotExecutor">The dot executor.</param>
        public GraphExpression(T graph, IFileService fileService, IDotExecutor dotExecutor)
        {
            this.graph = graph;
            this.fileService = fileService;
            this.dotExecutor = dotExecutor;
        }
        
        #endregion
        
        #region IGraphExpression Members

        /// <summary>
        /// Sets the name of the graph.
        /// </summary>
        /// <param name="graphName">Name of the graph.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithName(string graphName)
        {
            graph.Name = graphName;
            return this;
        }

        /// <summary>
        /// Sets the url property on the graph.
        /// </summary>
        /// <param name="url">The URL to set on the graph.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithURL(string url)
        {
            graph.Attributes.AddAttribute(new LabelAttribute(url));
            return this;
        }

        /// <summary>
        /// Sets the background color of the graph.
        /// </summary>
        /// <param name="color">The color to set the background to.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithBackgroundColor(Color color)
        {
            graph.Attributes.AddAttribute(new BackgroundColorAttribute(color));
            return this;
        }

        /// <summary>
        /// Sets the graph as concentrated - that is, to use edge concentrators.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression Concentrate()
        {
            graph.Attributes.AddAttribute(new ConcentrateAttribute(true));
            return this;
        }

        /// <summary>
        /// Centers the graph on the canvase.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression CenterOnCanvas()
        {
            graph.Attributes.AddAttribute(new CenterAttribute(true));
            return this;
        }

        /// <summary>
        /// Sets the font name that is used to label the graph.
        /// </summary>
        /// <param name="fontName">Name of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithFontName(string fontName)
        {
            graph.Attributes.AddAttribute(new FontNameAttribute(fontName));
            return this;
        }

        /// <summary>
        /// Sets the font size that is used to label the graph.
        /// </summary>
        /// <param name="fontSize">Size of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithFontSize(double fontSize)
        {
            graph.Attributes.AddAttribute(new FontSizeAttribute(fontSize));
            return this;
        }

        /// <summary>
        /// Sets the font color that is used to label the graph.
        /// </summary>
        /// <param name="fontColor">Color of the font to use.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithFontColor(Color fontColor)
        {
            graph.Attributes.AddAttribute(new FontColorAttribute(fontColor));
            return this;
        }

        /// <summary>
        /// Sets the label displayed on the graph.
        /// </summary>
        /// <param name="label">The label of the graph.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithLabel(string label)
        {
            graph.Attributes.AddAttribute(new LabelAttribute(label));
            return this;
        }

        /// <summary>
        /// Sets the justification of the graph label.
        /// </summary>
        /// <param name="justification">The justification of the graph label.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithLabelJustification(Justification justification)
        {
            graph.Attributes.AddAttribute(new LabelJustificationAttribute(justification));
            return this;
        }

        /// <summary>
        /// Sets the label location (top or bottom) of the graph label.
        /// </summary>
        /// <param name="location">The location of the graph label.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithLabelLocation(Location location)
        {
            graph.Attributes.AddAttribute(new LabelLocationAttribute(location));
            return this;
        }

        /// <summary>
        /// Writes the dot to the specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WriteDotTo(string fileName)
        {
            if (fileService.FileExists(fileName))
            {
                fileService.Delete(fileName);
            }

            fileService.WriteAllText(fileName, graph.ToDot());

            return this;
        }

        /// <summary>
        /// Specifies a custom attribute that should be applied to the graph.
        /// </summary>
        /// <param name="attribute">The attribute to apply to the graph.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithCustomAttribute(IDotAttribute attribute) {
            graph.Attributes.AddAttribute(attribute);
            return this;
        }

        /// <summary>
        /// Specifies the margin for the graph.
        /// </summary>
        /// <param name="x">The x margin.</param>
        /// <param name="y">The y margin.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithMargin(float x, float y)
        {
            graph.Attributes.AddAttribute(new MarginAttribute(x, y));
            return this;
        }

        /// <summary>
        /// Specifies the edge ordering in the graph.
        /// </summary>
        /// <param name="ordering">The ordering of edges to apply to the graph.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithEdgeOrdering(Ordering ordering)
        {
            graph.Attributes.AddAttribute(new OrderingAttribute(ordering));
            return this;
        }

        /// <summary>
        /// Renders the graph in landscape mode by rotating the graph 90 degrees.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression RenderLandscape()
        {
            graph.Attributes.AddAttribute(new RotateAttribute(90));
            return this;
        }

        /// <summary>
        /// Sets the minimum node seperation, in inches.
        /// </summary>
        /// <param name="inches">The inches to set the minimum node seperation to.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithMinimumNodeSeperation(double inches)
        {
            graph.Attributes.AddAttribute(new NodeSeperationAttribute(inches));
            return this;
        }

        /// <summary>
        /// Sets justification for multi-line labels off in the global context of the graph.
        /// </summary>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression DoNotJustify()
        {
            graph.Attributes.AddAttribute(new NoJustifyAttribute(true));
            return this;
        }

        /// <summary>
        /// Specifies the output order of thr graph.
        /// </summary>
        /// <param name="outputMode">The output mode the graph should use.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithOutputOrder(OutputMode outputMode)
        {
            graph.Attributes.AddAttribute(new OutputOrderAttribute(outputMode));
            return this;
        }

        /// <summary>
        /// Specifies the padding, in inches, to extend the drawing area around the graph.
        /// </summary>
        /// <param name="x">The x padding.</param>
        /// <param name="y">The y padding.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithPadding(float x, float y)
        {
            graph.Attributes.AddAttribute(new PadAttribute(x, y));
            return this;
        }

        /// <summary>
        /// Sets the output of the graph to split among pages with the specified width and height.
        /// Pages will be output in the direction set by the page direction.
        /// </summary>
        /// <param name="pageWidth">Width of the page.</param>
        /// <param name="pageHeight">Height of the page.</param>
        /// <returns>The current graph expression.</returns>
        /// <remarks>Only applicable for PostScript.</remarks>
        public IGraphExpression WithPageSize(float pageWidth, float pageHeight)
        {
            graph.Attributes.AddAttribute(new PageAttribute(pageWidth, pageHeight));
            return this;
        }

        /// <summary>
        /// If the graph is set as paged, this specifies the order in which pages are emitted.
        /// </summary>
        /// <param name="pageDirection">The page direction in which pages are emitted.</param>
        /// <returns>The current expression instance.</returns>
        public IGraphExpression WithPageDirection(PageDirection pageDirection)
        {
            graph.Attributes.AddAttribute(new PageDirectionAttribute(pageDirection));
            return this;}

        /// <summary>
        /// Sets the defaults entity values on this graph.
        /// </summary>
        /// <value>
        /// A defaults expression for setting default values for entities on the graph.
        /// </value>
        public IDefaultsExpression TheDefaults
        {
            get { return new DefaultsExpression(this, graph); }
        }

        /// <summary>
        /// Edits the conventions this graph should follow.
        /// </summary>
        /// <value>The conventions this graph should follow.</value>
        public IConventionCollectionModifiersExpression<IGraphExpression> Conventions
        {
            get { return new ConventionCollectionModifiersExpression<IGraphExpression>(this, graph.Conventions); }
        }

        /// <summary>
        /// Generates the dot.
        /// </summary>
        /// <returns>
        /// A string with the DOT for the the current created graph.
        /// </returns>
        public string GenerateDot()
        {
            return graph.ToDot();
        }

        /// <summary>
        /// Edits the node collection for this graph.
        /// </summary>
        /// <value>The expression for acting upon the node collection.</value>
        public INodeCollectionModifiersExpression<IGraphExpression> Nodes
        {
            get { return new NodeCollectionModifiersExpression<IGraphExpression>(graph, this); }
        }

        /// <summary>
        /// Edits the edge collection for this graph.
        /// </summary>
        /// <value>The expression for acting upon the edge collection.</value>
        public IEdgeCollectionModifiersExpression<IGraphExpression> Edges
        {
            get { return new EdgeCollectionModifiersExpression<IGraphExpression>(graph, this); }
        }

        /// <summary>
        /// Edits the cluster collection for this graph.
        /// </summary>
        /// <value>The expression for acting upon the cluster collection.</value>
        public IClusterCollectionModifiersExpression Clusters
        {
            get { return new ClusterCollectionModifiersExpression(graph, this); }
        }

        /// <summary>
        /// Instructs FluentDot to output to the specified filename.
        /// </summary>
        /// <param name="outputOptions">The output options.</param>
        public void Save(Action<IOutputExpression> outputOptions) {
            
            if (outputOptions == null)
            {
                throw new ArgumentNullException("outputOptions");
            }

            var expression = new OutputExpression();
            outputOptions(expression);

            var parameters = expression.OutputParameters;

            if (parameters.Count == 0)
            {
                throw new ArgumentException("No output destinations were specified.", "outputOptions");
            }

            dotExecutor.Execute(GenerateDot(), parameters);
        }
       

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the graph.
        /// </summary>
        /// <value>The graph.</value>
        public T Graph
        {
            get
            {
                return graph;
            }
        }

        #endregion
    }
}