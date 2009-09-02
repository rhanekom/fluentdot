/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class RecordElementExpressionTests {

        [Test]
        public void WithLabel_Sets_Label()
        {
            var element = new RecordElement("name");
            Assert.IsNotNull(new RecordElementExpression(element).WithLabel("customLabel"));

            Assert.AreEqual(element.Label, "customLabel");
        }

        [Test]
        public void IsInverted_Sets_Inverted()
        {
            var element = new RecordElement("name");
            Assert.IsNotNull(new RecordElementExpression(element).IsInverted());

            Assert.AreEqual(element.IsInverted, true);
        }
    }
}