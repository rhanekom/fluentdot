/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class RootRecordExpressionTests {

        [Test]
        public void Customize_Should_Apply_Configuration_To_Node()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var group = new RecordGroup();
            var node = new RecordNode("a", group);

            Assert.AreEqual(node.Attributes.CurrentAttributes.Count, 0);

            new RootRecordExpression(node).Customize(x => x.WithColor(Color.Black));

            Assert.AreEqual(node.Attributes.CurrentAttributes.Count, 1);
        }
    }
}