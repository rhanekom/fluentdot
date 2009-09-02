/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using FluentDot.Attributes;
using FluentDot.Attributes.Edges;
using FluentDot.Attributes.Shared;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Edges;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeExpressionTests {
        
        #region Tests

        [Test]
        public void WithLabel_Should_Add_Label_Attribute_To_Attributes() {
            AssertAttributeAdded(expression => expression.WithLabel("bb"),
                                 typeof(LabelAttribute), "bb");
        }

        [Test]
        public void WithTag_Should_Set_Tag_On_Edge() {
            var node1 = MockRepository.GenerateMock<IGraphNode>();
            var node2 = MockRepository.GenerateMock<IGraphNode>();
            var edge = new UndirectedEdge(new NodeTarget(node1), new NodeTarget(node2));

            var expression = new EdgeExpression(edge);
            expression.WithTag(5);
            
            Assert.AreEqual(edge.Tag, 5);
        }

        [Test]
        public void WithUrl_Should_Set_Url_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithUrl("http://www.google.com"),
                                 typeof(URLAttribute), "http://www.google.com");
        }

        [Test]
        public void WithColor_Applies_Color_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithColor(Color.Aqua),
                                 typeof(ColorAttribute), new ColorValue(Color.Aqua));
        }

        [Test]
        public void DoNotConstrainNodes_Should_Add_Constraint_Attribute()
        {
            AssertAttributeAdded(expression => expression.DoNotConstrainNodes(),
                                 typeof(ConstraintAttribute), new BooleanValue(false));
        }

        [Test]
        public void WithStyle_Should_Add_Style_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithStyle(EdgeStyle.Solid),
                                 typeof(StyleAttribute), EdgeStyle.Solid);
        }

        [Test]
        public void WithArrowHead_Should_Set_Arrow_Shape() {
            AssertAttributeAdded(expression => expression.WithArrowHead(ArrowShape.Crow),
                                 typeof(ArrowHeadAttribute), ArrowShape.Crow);
        }

        [Test]
        public void WithArrowHead_Should_Set_Composite_Arrow_Shape() {
            AssertAttributeAdded(expression => expression.WithArrowHead(new CompositeArrowShape(ArrowShape.Inverted, ArrowShape.Vee)),
                                 typeof(ArrowHeadAttribute), new CompositeArrowShape(ArrowShape.Inverted, ArrowShape.Vee));
        }

        [Test]
        public void WithArrowTail_Should_Set_Arrow_Shape() {
            AssertAttributeAdded(expression => expression.WithArrowTail(ArrowShape.Tee),
                                 typeof(ArrowTailAttribute), ArrowShape.Tee);
        }

        [Test]
        public void WithArrowTail_Should_Set_Composite_Arrow_Shape() {
            AssertAttributeAdded(expression => expression.WithArrowTail(new CompositeArrowShape(ArrowShape.Tee, ArrowShape.Dot)),
                                 typeof(ArrowTailAttribute), new CompositeArrowShape(ArrowShape.Tee, ArrowShape.Dot));
        }

        [Test]
        public void WithSize_Should_set_Size() {
            AssertAttributeAdded(expression => expression.WithArrowSize(0.5),
                                 typeof(ArrowSizeAttribute), 0.5);
        }

        [Test]
        public void WithDirection_Should_Set_Direction() {
            AssertAttributeAdded(expression => expression.WithArrowDirection(ArrowDirection.Forward),
                                 typeof(ArrowDirectionAttribute), ArrowDirection.Forward);
        }

        [Test]
        public void WithFontColor_Should_Set_FontColor()
        {
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
        public void WithCustomAttribute_Should_Apply_Attribute() {
            var attribute = MockRepository.GenerateMock<IDotAttribute>();
            attribute.Expect(x => x.Value).Return("aa");

            AssertAttributeAdded(expression => expression.WithCustomAttribute(attribute),
                                 attribute.GetType(), "aa");
        }

        [Test]
        public void WithLabelAngle_Should_Set_Label_Angle()
        {
            AssertAttributeAdded(expression => expression.WithLabelAngle(2.0),
                                 typeof(LabelAngleAttribute), 2.0);
        }

        [Test]
        public void WithLabelDistance_Should_Set_Label_Distance()
        {
            AssertAttributeAdded(expression => expression.WithLabelDistance(2.0),
                                 typeof(LabelDistanceAttribute), 2.0);
        }

        [Test]
        public void FloatLabel_Should_Set_Float_To_True() {
            AssertAttributeAdded(expression => expression.FloatLabel(),
                                 typeof(LabelFloatAttribute), new BooleanValue(true));
        }

        [Test]
        public void WithHeadLabel_Sets_Head_Label()
        {
            AssertAttributeAdded(expression => expression.WithHeadLabel("bla"),
                                 typeof(HeadLabelAttribute), "bla");
        }

        [Test]
        public void WithTailLabel_Sets_Tail_Label()
        {
            AssertAttributeAdded(expression => expression.WithTailLabel("bla"),
                                 typeof(TailLabelAttribute), "bla");
        }

        [Test]
        public void WithLabelFontName_Sets_Label_Font_Name()
        {
            AssertAttributeAdded(expression => expression.WithLabelFontName("bla"),
                                 typeof(LabelFontNameAttribute), "bla");
        }

        [Test]
        public void WithLabelFontSize_Sets_Label_Font_Size() {
            AssertAttributeAdded(expression => expression.WithLabelFontSize(5.4),
                                 typeof(LabelFontSizeAttribute), 5.4);
        }

        [Test]
        public void WithLabelFontColor_Sets_Label_Font_Color() {
            AssertAttributeAdded(expression => expression.WithLabelFontColor(Color.Azure),
                                 typeof(LabelFontColorAttribute), new ColorValue(Color.Azure));
        }

        [Test]
        public void WithMinimumLength_Should_Set_Minimum_Length()
        {
            AssertAttributeAdded(expression => expression.WithMinimumLength(3),
                                 typeof(MinimumLengthAttribute), 3);
        }

        [Test]
        public void DoNotJustify_Should_set_NoJustification()
        {
            AssertAttributeAdded(expression => expression.DoNotJustify(),
                                 typeof(NoJustifyAttribute), new BooleanValue(true));
        }

        #endregion

        #region Private Members

        private static void AssertAttributeAdded(Action<IEdgeExpression> action, Type attributeType, object attributeValue) {
            AssertAttributeAdded(action, attributeType, attributeValue, null);
        }

        private static void AssertAttributeAdded(Action<IEdgeExpression> action, Type attributeType, object attributeValue, Action<IEdge> customAsserts) {
            var node1 = MockRepository.GenerateMock<IGraphNode>();
            var node2 = MockRepository.GenerateMock<IGraphNode>();
            var edge = new DirectedEdge(new NodeTarget(node1), new NodeTarget(node2));

            var expression = new EdgeExpression(edge);
            action(expression);

            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 1);

            var attribute = edge.Attributes.CurrentAttributes[0];
            Assert.IsInstanceOfType(attributeType, attribute);
            Assert.AreEqual(attribute.Value, attributeValue);

            if (customAsserts != null) {
                customAsserts(edge);
            }
        }

        #endregion
    }
}