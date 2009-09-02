/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;
using FluentDot.Attributes;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class AbstractGraphTests {

        #region Tests

        [Test]
        public void AddNode_Should_Add_Node_To_Node_Collection()
        {
            var graph = new TestGraph();
            graph.AddNode(new GraphNode("a"));

            Assert.AreEqual(graph.Nodes.Count(), 1);
            Assert.AreEqual(graph.Nodes.First().Name, "a");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNode_Should_Throw_If_Node_Null() {
            new TestGraph().AddNode(null);
        }


        [Test]
        public void AddEdge_Should_Add_Edge_To_Edge_Collection() {

            var node1 = MockRepository.GenerateMock<IGraphNode>();
            var node2 = MockRepository.GenerateMock<IGraphNode>();
            var edge = new DirectedEdge(new NodeTarget(node1), new NodeTarget(node2));

            var graph = new TestGraph();

            graph.AddEdge(edge);

            Assert.AreEqual(graph.Edges.Count(), 1);
            Assert.AreSame(graph.Edges.First(), edge);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void AddEdge_Should_Throw_If_edge_Null() {
            new TestGraph().AddEdge(null);
        }

        [Test]
        public void ToDot_Should_Append_Nodes()
        {
            var graph = new TestGraph();
            graph.AddNode(new GraphNode("a"));
            graph.AddNode(new GraphNode("b"));

            string dot = graph.ToDot();
            Assert.IsTrue(dot.Contains(graph.Nodes.First().Attributes.ToDot() + Environment.NewLine));
            Assert.IsTrue(dot.Contains(graph.Nodes.Skip(1).First().Attributes.ToDot() + Environment.NewLine));
        }

        [Test]
        public void ToDot_Should_Add_Attributes_To_Graph()
        {
            var attribute = MockRepository.GenerateMock<IDotAttribute>();
            attribute.Expect(x => x.ToDot()).Return("a=bb");

            var graph = new TestGraph {Name = "a"};
            graph.Attributes.AddAttribute(attribute);

            string dot = graph.ToDot();

            attribute.VerifyAllExpectations();

            Assert.IsTrue(Regex.Match(dot, "^testGraph \\\"a\\\" {[^}]*graph \\[a=bb\\][^}]*}$", RegexOptions.Multiline).Success);
        }
       

        [Test]
        public void AddCluster_Should_Add_Cluster()
        {
            var cluster = MockRepository.GenerateMock<ICluster>();
            cluster.Expect(x => x.Name).Return("a");

            var graph = new TestGraph();
            graph.AddCluster(cluster);

            Assert.AreEqual(graph.ClusterLookup.Clusters.Count(), 1);
            Assert.AreEqual(graph.ClusterLookup.Clusters.First(), cluster);
        }

        #endregion

        #region Private Members

        private class TestGraph : AbstractGraph
        {
            public override GraphType Type
            {
                get { return GraphType.Undirected; }
            }

            protected override string GraphIndicator {
                get { return "testGraph"; }
            }
        }

        #endregion
    }
}