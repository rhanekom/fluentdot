/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Drawing;
using System.IO;
using FluentDot.Attributes;
using FluentDot.Attributes.Nodes;
using FluentDot.Attributes.Shared;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class NodeExpressionTests {

        #region Tests

        [Test]
        public void WithLabel_Should_Add_Label_Attribute_To_Attributes()
        {
            AssertAttributeAdded(expression => expression.WithLabel("bb"),
                                 typeof(LabelAttribute), "bb");
        }

        [Test]
        public void WithTag_Should_Set_Tag_On_Node()
        {
            var node = new GraphNode("gg");
            var expression = new NodeExpression(node);
            expression.WithTag(5);

            Assert.AreEqual(node.Tag, 5);
        }

        [Test]
        public void WithColor_Should_Add_Color_Attribute_To_Attributes() {
            AssertAttributeAdded(expression => expression.WithColor(Color.Red), 
                                 typeof(ColorAttribute), new ColorValue(Color.Red));
        }

        [Test]
        public void WithURL_Should_Add_URL_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithUrl("http://www.google.com"),
                                 typeof(URLAttribute), "http://www.google.com");
        }

        [Test]
        public void WithShape_Should_Set_Shape_Attribute()
        {
            AssertAttributeAdded(expression => expression.WithShape(NodeShape.House),
                                 typeof(NodeShapeAttribute), NodeShape.House);
        }

        [Test]
        public void WithFillColor_Should_Set_FillColor()
        {
            AssertAttributeAdded(expression => expression.WithFillColor(Color.Cyan),
                                 typeof(FillColorAttribute), new ColorValue(Color.Cyan));
        }

        [Test]
        public void WithStyle_Should_Add_StyleAttribute()
        {
            AssertAttributeAdded(expression => expression.WithStyle(NodeStyle.Dotted),
                                 typeof(StyleAttribute), NodeStyle.Dotted);
        }
        
        [Test]
        public void WithHeight_Adds_Height_Attribute_To_Node() {
            AssertAttributeAdded(x => x.WithHeight(1.2), typeof(HeightAttribute), 1.2);
        }

        [Test]
        public void WithWidth_Adds_Width_Attribute_To_Node() {
            AssertAttributeAdded(x => x.WithWidth(1.2), typeof(WidthAttribute), 1.2);
        }

        [Test]
        public void IsFixedSize_Adds_FixedSize_Attribute_To_Node() {
            AssertAttributeAdded(x => x.IsFixedSize(), typeof(FixedSizeAttribute), new BooleanValue(true));
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
        public void BelongsToGroup_Should_Set_Group()
        {
            AssertAttributeAdded(expression => expression.BelongsToGroup("testGroup1"),
                                 typeof(GroupAttribute), "testGroup1");
        }

        [Test]
        public void ContainsImage_Should_Add_Image()
        {
            AssertAttributeAdded(expression => expression.ContainsImage("FluentDot.Tests.dll"),
                                 typeof(ImageAttribute), Path.GetFullPath("FluentDot.Tests.dll"));
        }

        [Test]
        public void WithLabelLocation_Should_Add_Label_Location()
        {
            AssertAttributeAdded(expression => expression.WithLabelLocation(Location.Bottom),
                                 typeof(LabelLocationAttribute), Location.Bottom);
        }

        [Test]
        public void WithLabelMargin_Should_Set_Margin()
        {
            AssertAttributeAdded(expression => expression.WithLabelMargin(10, 15),
                                 typeof(MarginAttribute), new PointValue(10, 15));
        }

        [Test]
        public void ContainsScaledImage_Should_Add_Image_And_Scaled_Attribute() {
        
            var node = new GraphNode("gg");
            var expression = new NodeExpression(node);
            expression.ContainsScaledImage("FluentDot.Tests.dll");

            Assert.AreEqual(node.Attributes.CurrentAttributes.Count, 2);

            AssertAttributeAdded(node.Attributes.CurrentAttributes[0], typeof(ImageAttribute), Path.GetFullPath("FluentDot.Tests.dll"));
            AssertAttributeAdded(node.Attributes.CurrentAttributes[1], typeof(ImageScaleAttribute), new BooleanValue(true));
        }

        [Test]
        public void WithCustomAttribute_Should_Apply_Attribute() {
            var attribute = MockRepository.GenerateMock<IDotAttribute>();
            attribute.Expect(x => x.Value).Return("aa");

            AssertAttributeAdded(expression => expression.WithCustomAttribute(attribute),
                                 attribute.GetType(), "aa");
        }

        [Test]
        public void DoNotJustify_Should_set_NoJustification()
        {
            AssertAttributeAdded(expression => expression.DoNotJustify(),
                                 typeof(NoJustifyAttribute), new BooleanValue(true));
        }

        [TearDown]
        public void WithOrientation_Should_Set_Orientation()
        {
            AssertAttributeAdded(expression => expression.WithOrientation(30),
                                 typeof(OrientationAttribute), 30);
        }

        [Test]
        public void WithPenWidth_Should_Set_PenWidth() {
            AssertAttributeAdded(expression => expression.WithPenWidth(1.3),
                                 typeof(PenWidthAttribute), 1.3);
        }

        [Test]
        public void WithPeripheries_Should_Set_Peripheries() {
            AssertAttributeAdded(expression => expression.WithPeripheries(2),
                                 typeof(PeripheriesAttribute), 2);
        }

        #endregion

        #region Private Members

        private static void AssertAttributeAdded(Action<INodeExpression> action, Type attributeType, object attributeValue)
        {
            AssertAttributeAdded(action, attributeType, attributeValue, null);
        }

        private static void AssertAttributeAdded(Action<INodeExpression> action, Type attributeType, object attributeValue, Action<IGraphNode> customAsserts)
        {
            var node = new GraphNode("gg");
            var expression = new NodeExpression(node);
            action(expression);
            
            Assert.AreEqual(node.Attributes.CurrentAttributes.Count, 1);

            AssertAttributeAdded(node.Attributes.CurrentAttributes[0], attributeType, attributeValue);

            if (customAsserts != null)
            {
                customAsserts(node);
            }
        }

        private static void AssertAttributeAdded(IDotAttribute attribute, Type attributeType, object attributeValue)
        {
            Assert.IsInstanceOfType(attributeType, attribute);
            Assert.AreEqual(attribute.Value, attributeValue);
        }

        #endregion
    }
}