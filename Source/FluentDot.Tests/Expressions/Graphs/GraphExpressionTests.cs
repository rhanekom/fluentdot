/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using FluentDot.Attributes;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using FluentDot.Common;
using FluentDot.Entities.Graphs;
using FluentDot.Execution;
using FluentDot.Expressions.Graphs;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentDot.Tests.Expressions.Graphs
{
    [TestFixture]
    public class GraphExpressionTests {

        #region Tests

        [Test]
        public void WithName_Sets_Graph_Name_Correctly() {
            var graphExpression = new TestGraphExpression();

            IGraph graph = graphExpression.Graph;

            graph.Expect(x => x.Name = "testName");

            var instance = graphExpression.WithName("testName");
            Assert.AreSame(instance, graphExpression);

            graph.VerifyAllExpectations();
        }

        [Test]
        public void GenerateDot_Should_Return_Dot_From_Graph()
        {
            var graphExpression = new TestGraphExpression();

            IGraph graph = graphExpression.Graph;

            graph.Expect(x => x.ToDot()).Return("bla");

            var dot = graphExpression.GenerateDot();

            graph.VerifyAllExpectations();

            Assert.AreEqual(dot, "bla");
        }

        [Test]
        public void WriteDotTo_Should_Write_File_To_Disk()
        {
            const string fileName = "c:\\tmp.dot";

            var graphExpression = new TestGraphExpression();

            IGraph graph = graphExpression.Graph;
            graph.Expect(x => x.Name = "testName");
            graph.Expect(x => x.ToDot()).Return("dotty");

            IFileService fileService = graphExpression.FileService;
            fileService.Expect(x => x.FileExists(fileName)).Return(false);
            fileService.Expect(x => x.WriteAllText(fileName, "dotty"));

            var instance = graphExpression.WithName("testName").WriteDotTo(fileName);

            Assert.AreSame(instance, graphExpression);

            graph.VerifyAllExpectations();
            fileService.VerifyAllExpectations();
        }

        [Test]
        public void WriteDotTo_Should_Delete_File_If__It_Allready_Exists() {
            const string fileName = "c:\\tmp.dot";

            var graphExpression = new TestGraphExpression();

            IGraph graph = graphExpression.Graph;
            graph.Expect(x => x.Name = "testName");
            graph.Expect(x => x.ToDot()).Return("dotty");

            IFileService fileService = graphExpression.FileService;
            fileService.Expect(x => x.FileExists(fileName)).Return(true);
            fileService.Expect(x => x.Delete(fileName));
            fileService.Expect(x => x.WriteAllText(fileName, "dotty"));

            var instance = graphExpression.WithName("testName").WriteDotTo(fileName);

            Assert.AreSame(instance, graphExpression);

            graph.VerifyAllExpectations();
            fileService.VerifyAllExpectations();
        }

        [Test]
        public void Save_Should_Apply_Configuration_And_Call_DotExecutor()
        {
            const string fileName1 = "c:\\tmp1.dot";
            const string fileName2 = "c:\\tmp2.dot";
            
            var graphExpression = new TestGraphExpression();

            graphExpression.DotExecutor.Expect(x => x.Execute(null, null))
                .IgnoreArguments()
                .Constraints(
                Is.Matching<string>(x => x == graphExpression.GenerateDot()),
                Is.Matching<IList<OutputFileWithFormatParameter>>(
                    p => p.Count == 2 &&
                         p[0].OutputFile.FileName == fileName1 &&
                         p[0].Format == OutputFormat.GIF &&
                         p[1].OutputFile.FileName == fileName2 &&
                         p[1].Format == OutputFormat.Canon
                    )
                );


            graphExpression.Save(x => {
                                          x.ToFile(fileName1).UsingFormat(OutputFormat.GIF);
                                          x.ToFile(fileName2).UsingFormat(OutputFormat.Canon);
            });
        }

        [Test]
        public void Clusters_Does_Not_Return_Null()
        {
            Assert.IsNotNull(new TestGraphExpression().Clusters);
        }

        [Test]
        public void SubGraphs_Does_Not_Return_Null() {
            Assert.IsNotNull(new TestGraphExpression().SubGraphs);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Save_Should_Throw_If_Null_Was_Passed()
        {
            new TestGraphExpression().Save(null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Save_Should_Throw_If_No_Files_Were_Passed() {
            new TestGraphExpression().Save(x => { });
        }

        [Test]
        public void Nodes_Should_Return_Not_Return_Null()
        {
            Assert.IsNotNull(new TestGraphExpression().Nodes);
        }

        [Test]
        public void WithRankDirection_Sets_RankDirection_Attribute()
        {
            AssertAttributeAdded(x => x.WithRankDirection(RankDirection.TopToBottom), typeof(RankDirectionAttribute), RankDirection.TopToBottom);
        }

        [Test]
        public void Edges_Should_Return_Not_Null() {
            Assert.IsNotNull(new TestGraphExpression().Edges);
        }

        [Test]
        public void WithUrl_Should_Add_Url_Attribute()
        {
            AssertAttributeAdded(x => x.WithURL("http://www.google.com"), typeof(LabelAttribute), "http://www.google.com");
        }

        [Test]
        public void WithBackgroundColor_Should_Add_BackgroundColor_Attribute()
        {
            AssertAttributeAdded(x => x.WithBackgroundColor(Color.Violet), typeof(BackgroundColorAttribute), new ColorValue(Color.Violet));
        }

        [Test]
        public void CenterOnCanvas_Should_Add_Centered_Attribute()
        {
            AssertAttributeAdded(x => x.CenterOnCanvas(), typeof(CenterAttribute), new BooleanValue(true));
        }

        [Test]
        public void Concentrate_Should_Add_Concentrate_Attribute()
        {
            AssertAttributeAdded(x => x.Concentrate(), typeof(ConcentrateAttribute), new BooleanValue(true));
        }

        [Test]
        public void WithClusterRankMode_Should_Add_ClusterRank_Attribute()
        {
            AssertAttributeAdded(x => x.WithClusterRankMode(ClusterMode.Local), typeof(ClusterRankAttribute), ClusterMode.Local);
        }

        [Test]
        public void WithFontColor_Should_Set_FontColor() {
            AssertAttributeAdded(expression => expression.WithFontColor(Color.BlanchedAlmond),
                                 typeof(FontColorAttribute), new ColorValue(Color.BlanchedAlmond));
        }

        [Test]
        public void WithFontName_Should_Set_FontName() {
            AssertAttributeAdded(expression => expression.WithFontName("Times-Roman"),
                                 typeof(FontNameAttribute), "Times-Roman");
        }

        [Test]
        public void WithFontSize_Should_Set_FontSize() {
            AssertAttributeAdded(expression => expression.WithFontSize(2.0),
                                 typeof(FontSizeAttribute), 2.0);
        }

        [Test]
        public void WithLabel_Should_Set_Label()
        {
            AssertAttributeAdded(expression => expression.WithLabel("testLabel"),
                                 typeof(LabelAttribute), "testLabel");
        }

        [Test]
        public void WithCustomAttribute_Should_Apply_Attribute()
        {
            var attribute = MockRepository.GenerateMock<IDotAttribute>();
            attribute.Expect(x => x.Value).Return("aa");

            AssertAttributeAdded(expression => expression.WithCustomAttribute(attribute),
                                 attribute.GetType(), "aa");
        }

        [Test]
        public void WithLabelLocation_Should_Set_Label_Location()
        {
            AssertAttributeAdded(expression => expression.WithLabelLocation(Location.Top),
                                 typeof(LabelLocationAttribute), Location.Top);
        }

        [Test]
        public void WithLabelJustification_Should_Set_Label_Justification() {
            AssertAttributeAdded(expression => expression.WithLabelJustification(Justification.Left),
                                 typeof(LabelJustificationAttribute), Justification.Left);
        }

        [Test]
        public void RenderLandscape_Should_Set_Rotation()
        {
            AssertAttributeAdded(expression => expression.RenderLandscape(),
                                 typeof(RotateAttribute), 90);
        }

        [Test]
        public void WithLabelMargin_Should_Set_Margin() {
            AssertAttributeAdded(expression => expression.WithMargin(10, 15),
                                 typeof(MarginAttribute), new PointValue(10, 15));
        }

        [Test]
        public void WithMinimumNodeSeperation_Should_Set_Node_Seperation()
        {
            AssertAttributeAdded(expression => expression.WithMinimumNodeSeperation(2),
                                 typeof(NodeSeperationAttribute), 2);
        }

        [Test]
        public void DoNotJustify_Should_set_NoJustification()
        {
            AssertAttributeAdded(expression => expression.DoNotJustify(),
                                 typeof(NoJustifyAttribute), new BooleanValue(true));
        }

        [Test]
        public void DefaultsFor_Does_Not_Return_Null()
        {
            Assert.IsNotNull(new TestGraphExpression().TheDefaults);
        }

        [Test]
        public void WithOutputOrder_Should_Set_Output_Order()
        {
            AssertAttributeAdded(expression => expression.WithOutputOrder(OutputMode.NodesFirst),
                                 typeof(OutputOrderAttribute), OutputMode.NodesFirst);
        }

        [Test]
        public void WithPadding_Should_Set_Padding()
        {
            AssertAttributeAdded(expression => expression.WithPadding(0.1f, 0.09f),
                                 typeof(PadAttribute), new PointValue(0.1f, 0.09f));
        }

        [Test]
        public void WithPageDirection_Should_Set_PageDirection()
        {
            AssertAttributeAdded(expression => expression.WithPageDirection(PageDirection.BottomToTopRightToLeft),
                                 typeof(PageDirectionAttribute), PageDirection.BottomToTopRightToLeft);
        }

        [Test]
        public void WithPageSize_Sets_Page_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithPageSize(2.3f, 4.5f),
                                 typeof(PageAttribute), new PointValue(2.3f, 4.5f));
        }

        [Test]
        public void WithRatio_Ratio_Sets_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithRatio(Ratio.Compress),
                                 typeof(RatioAttribute), Ratio.Compress);
        }

        [Test]
        public void WithRatio_Value_Sets_Attribute() {
            AssertAttributeAdded(expression => expression.WithRatio(2.4),
                                 typeof(RatioAttribute), 2.4);
        }

        [Test]
        public void WithComment_Should_Set_Comment()
        {
            AssertAttributeAdded(expression => expression.WithComment("testComment"),
                                typeof(CommentAttribute), "testComment");
        }

        [Test]
        public void WithAspect_Adds_Aspect_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithAspect(2.2),
                                typeof(AspectAttribute), new AspectValue(2.2));
        }

        [Test]
        public void WithAspect_And_Passes_Adds_Aspect_Attribute() {
            AssertAttributeAdded(expression => expression.WithAspect(2.2, 5),
                                typeof(AspectAttribute), new AspectValue(2.2, 5));
        }
        
        [Test]
        public void Compound_Adds_Compound_Attribute_With_True_Value() {
            AssertAttributeAdded(expression => expression.Compound(),
                                typeof(CompoundAttribute), new BooleanValue(true));
        }

        [Test]
        public void WithEqualRankSeperation_Adds_RankSeperation_With_Equal_Seperation()
        {
            AssertAttributeAdded(expression => expression.WithEqualRankSeperation(),
                                typeof(RankSeperationAttribute), new RankSeperation(null, true));
        }

        [Test]
        public void WithRankSeperation_Adds_RankSeperation_With_Inches_And_EqualSeperationIndicator()
        {
            AssertAttributeAdded(expression => expression.WithRankSeperation(1.33, true),
                                typeof(RankSeperationAttribute), new RankSeperation(1.33, true));
        }
        
        #endregion

        #region Private Members

        private static void AssertAttributeAdded(Action<IGraphExpression> action, Type attributeType, object attributeValue) {
            AssertAttributeAdded(action, attributeType, attributeValue, null);
        }

        private static void AssertAttributeAdded(Action<IGraphExpression> action, Type attributeType, object attributeValue, Action<IGraph> customAsserts) {
            var expression = new TestGraphExpression();

            var attributes = new AttributeCollection();

            expression.Graph.Expect(x => x.Attributes).Return(attributes);

            action(expression);

            Assert.AreEqual(attributes.CurrentAttributes.Count, 1);

            var attribute = attributes.CurrentAttributes[0];
            Assert.IsInstanceOfType(attributeType, attribute);
            Assert.AreEqual(attribute.Value, attributeValue);

            if (customAsserts != null) {
                customAsserts(expression.Graph);
            }

            expression.Graph.VerifyAllExpectations();
        }
        
        private class TestGraphExpression : GraphExpression<IGraph> {
            
            private readonly IFileService fileService;
            private readonly IDotExecutor dotExecutor;

            public TestGraphExpression() : this(
                MockRepository.GenerateMock<IGraph>(), 
                MockRepository.GenerateMock<IFileService>(),
                MockRepository.GenerateMock<IDotExecutor>()
                ) {

                }

            private TestGraphExpression(IGraph graph, IFileService fileService, IDotExecutor dotExecutor)
                : base(graph, fileService, dotExecutor) {
                this.fileService = fileService;
                this.dotExecutor = dotExecutor;
                }
            
            public IFileService FileService { get { return fileService; } }

            public IDotExecutor DotExecutor { get { return dotExecutor; } }
        }

        #endregion
    }
}