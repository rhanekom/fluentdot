/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Edges
{
    [TestFixture]
    public class AbstractEdgeTests {

        #region Tests

        [Test]
        public void ToDot_Uses_Edge_Indicator()
        {
            var a = new GraphNode("a");
            var b = new GraphNode("b");

            var edge = new TestEdge(a, b);
            Assert.AreEqual(edge.ToDot(), "\"a\" ** \"b\"");
        }

        [Test]
        public void ToDot_Ouputs_Attributes()
        {
            var a = new GraphNode("a");
            var b = new GraphNode("b");

            var attribute = MockRepository.GenerateMock<IDotAttribute>();
            attribute.Expect(x => x.ToDot()).Return("att=custom");
            
            var edge = new TestEdge(a, b);
            edge.Attributes.AddAttribute(attribute);
            Assert.AreEqual(edge.ToDot(), "\"a\" ** \"b\" [att=custom]");
        }

        #endregion

        #region Private Members

        private class TestEdge : AbstractEdge
        {
            public TestEdge(IGraphNode fromNode, IGraphNode toNode)
                : base(new NodeTarget(fromNode), new NodeTarget(toNode))
            {

            }

            protected override string EdgeIndicator {
                get { return "**"; }
            }
        }

        #endregion
    }
}