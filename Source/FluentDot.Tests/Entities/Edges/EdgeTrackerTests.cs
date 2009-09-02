/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Linq;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Edges
{
    [TestFixture]
    public class EdgeTrackerTests {

        [Test]
        public void Add_Should_Add_Edge_To_Collection() {
            var tracker = new EdgeTracker();

            var node1 = MockRepository.GenerateMock<IGraphNode>();
            var node2 = MockRepository.GenerateMock<IGraphNode>();

            var edge = new DirectedEdge(new NodeTarget(node1), new NodeTarget(node2));
            tracker.AddEdge(edge);
            Assert.AreEqual(tracker.Edges.Count(), 1);
            Assert.AreSame(tracker.Edges.First(), edge);
        }

        [Test]
        public void GetEdgeByTag_Should_Retrieve_Node_By_Tag() {
            var tracker = new EdgeTracker();

            var node1 = MockRepository.GenerateMock<IGraphNode>();
            var node2 = MockRepository.GenerateMock<IGraphNode>();
            var node3 = MockRepository.GenerateMock<IGraphNode>();
            var node4 = MockRepository.GenerateMock<IGraphNode>();

            var edge1 = new UndirectedEdge(new NodeTarget(node1), new NodeTarget(node2)) {Tag = 1};
            var edge2 = new UndirectedEdge(new NodeTarget(node3), new NodeTarget(node4)) { Tag = 2 };

            tracker.AddEdge(edge1);
            tracker.AddEdge(edge2);

            Assert.AreEqual(tracker.Edges.Count(), 2);

            Assert.AreSame(tracker.GetEdgeByTag(1), edge1);
            Assert.AreSame(tracker.GetEdgeByTag(2), edge2);
        }

        [Test]
        public void GetEdgeByTag_With_Invalid_Tag_Should_Return_Null() {
            var tracker = new EdgeTracker();

            var node1 = MockRepository.GenerateMock<IGraphNode>();
            var node2 = MockRepository.GenerateMock<IGraphNode>();

            var edge = new UndirectedEdge(new NodeTarget(node1), new NodeTarget(node2));
            tracker.AddEdge(edge);

            Assert.AreEqual(tracker.Edges.Count(), 1);

            Assert.IsNull(tracker.GetEdgeByTag(2));
        }
    }
}