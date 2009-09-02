/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class RecordExpressionTests {

        [Test]
        public void WithElement_Adds_New_Element()
        {
            var recordGroup = new RecordGroup();
            var expression = new RecordExpression(recordGroup);
            Assert.IsNotNull(expression.WithElement("elementName"));
            Assert.AreEqual(recordGroup.Elements.Count, 1);
            Assert.AreEqual(((RecordElement)recordGroup.Elements[0]).Name, "elementName");
        }

        [Test]
        public void WithGroup_Adds_New_Group()
        {
            var recordGroup = new RecordGroup();
            var expression = new RecordExpression(recordGroup);
            Assert.IsNotNull(expression.WithGroup(x => x.WithElement(("elementName"))));
            Assert.AreEqual(recordGroup.Elements.Count, 1);

            var group = ((RecordGroup)recordGroup.Elements[0]);
            Assert.AreEqual(group.Elements.Count, 1);

            Assert.AreEqual(((RecordElement)group.Elements[0]).Name, "elementName");
        }

        [Test]
        public void WithElement_Applies_Custom_Configuration()
        {
            var recordGroup = new RecordGroup();
            var expression = new RecordExpression(recordGroup);
            Assert.IsNotNull(expression.WithElement("elementName", x => x.WithLabel("bla")));
            Assert.AreEqual(recordGroup.Elements.Count, 1);
            Assert.AreEqual(((RecordElement)recordGroup.Elements[0]).Label, "bla");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void WithElement_Should_Throw_For_Duplicate_Elements() {
            var recordGroup = new RecordGroup();
            var expression = new RecordExpression(recordGroup);
            expression.WithElement("a");
            expression.WithElement("a");
        }
    }
}