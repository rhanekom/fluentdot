/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Edges
{
    [TestFixture]
    public class DirectedEdgeTests {

        [Test]
        public void Constructor_Should_Save_Arguments() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();
            var toNode = MockRepository.GenerateMock<IGraphNode>();

            var edge = new DirectedEdge(new NodeTarget(fromNode), new NodeTarget(toNode));
            Assert.AreSame(fromNode, edge.From.Node);
            Assert.AreSame(toNode, edge.To.Node);
        }
    }
}