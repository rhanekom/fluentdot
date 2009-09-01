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
using FluentDot.Entities;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Graphs;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Graphs
{
    [TestFixture]
    public class ClusterExpressionTests
    {
        #region Tests

        [Test]
        public void WithName_Sets_Name_On_Cluster()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.Type).Return(GraphType.Directed);
            graph.Expect(x => x.NodeLookup).Return(nodeTracker);
            graph.Expect(x => x.EdgeLookup).Return(edgeTracker);

            var expression = new ClusterExpression(graph);
            expression.WithName("blabla");

            Assert.IsTrue(expression.Cluster.Name.Contains("blabla"));
        }

        [Test]
        public void WithColor_Applies_Color_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithColor(Color.Aqua),
                                 typeof(ColorAttribute), new ColorValue(Color.Aqua));
        }

        [Test]
        public void WithLabel_Should_Set_Label() {
            AssertAttributeAdded(expression => expression.WithLabel("testLabel"),
                                 typeof(LabelAttribute), "testLabel");
        }

        [Test]
        public void WithUrl_Should_Set_Url_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithUrl("http://www.google.com"),
                                 typeof(URLAttribute), "http://www.google.com");
        }

        [Test]
        public void WithBackgroundColor_Should_Add_BackgroundColor_Attribute()
        {
            AssertAttributeAdded(x => x.WithBackgroundColor(Color.Violet), typeof(BackgroundColorAttribute), new ColorValue(Color.Violet));
        }

        [Test]
        public void WithFillColor_Should_Set_FillColor()
        {
            AssertAttributeAdded(expression => expression.WithFillColor(Color.Cyan),
                                 typeof(FillColorAttribute), new ColorValue(Color.Cyan));
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
        public void WithLabelLocation_Should_Set_Label_Location() {
            AssertAttributeAdded(expression => expression.WithLabelLocation(Location.Top),
                                 typeof(LabelLocationAttribute), Location.Top);
        }

        [Test]
        public void WithLabelJustification_Should_Set_Label_Justification() {
            AssertAttributeAdded(expression => expression.WithLabelJustification(Justification.Left),
                                 typeof(LabelJustificationAttribute), Justification.Left);
        }

        [Test]
        public void DoNotJustify_Should_set_NoJustification() {
            AssertAttributeAdded(expression => expression.DoNotJustify(),
                                 typeof(NoJustifyAttribute), new BooleanValue(true));
        }

        [Test]
        public void WithStyle_Should_Add_Style_Attribute() {
            AssertAttributeAdded(expression => expression.WithStyle(ClusterStyle.Filled),
                                 typeof(StyleAttribute), ClusterStyle.Filled);
        }

        #endregion

        #region Private Members

        private static void AssertAttributeAdded(Action<IClusterExpression> action, Type attributeType, object attributeValue)
        {
            AssertAttributeAdded(action, attributeType, attributeValue, null);
        }

        private static void AssertAttributeAdded(Action<IClusterExpression> action, Type attributeType, object attributeValue, Action<ICluster> customAsserts)
        {
            var graph = new DirectedGraph();
            var expression = new ClusterExpression(graph);
            action(expression);

            var cluster = expression.Cluster;

            Assert.AreEqual(cluster.Attributes.CurrentAttributes.Count, 1);

            var attribute = cluster.Attributes.CurrentAttributes[0];
            Assert.IsInstanceOfType(attributeType, attribute);
            Assert.AreEqual(attribute.Value, attributeValue);

            if (customAsserts != null)
            {
                customAsserts(expression.Cluster);
            }
        }

        #endregion
    }
}