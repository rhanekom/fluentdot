/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class ClusterTests {

        [Test]
        public void Constructor_Saves_Graph_Type()
        {
            var graph = new Mock<IGraph>();
            var edgeTracker = new Mock<IEdgeTracker>();
            var nodeTracker = new Mock<INodeTracker>();

            graph.Setup(x => x.EdgeLookup).Returns(edgeTracker.Object);
            graph.Setup(x => x.NodeLookup).Returns(nodeTracker.Object);
            graph.Setup(x => x.Type).Returns(GraphType.Directed);

            Assert.AreEqual(new Cluster(graph.Object).Type, GraphType.Directed);
        }
       

        [Test]
        public void Name_Should_Prepend_Cluster_To_Given_Name()
        {
            var graph = new Mock<IGraph>();
            var edgeTracker = new Mock<IEdgeTracker>();
            var nodeTracker = new Mock<INodeTracker>();

            graph.Setup(x => x.EdgeLookup).Returns(edgeTracker.Object);
            graph.Setup(x => x.NodeLookup).Returns(nodeTracker.Object);
            graph.Setup(x => x.Type).Returns(GraphType.Directed);

            Assert.IsTrue(new Cluster(graph.Object).Name.StartsWith("cluster"));
        }

        [Test]
        public void Name_Should_Throw_For_Null()
        {
            var graph = new Mock<IGraph>();
            var edgeTracker = new Mock<IEdgeTracker>();
            var nodeTracker = new Mock<INodeTracker>();

            graph.Setup(x => x.EdgeLookup).Returns(edgeTracker.Object);
            graph.Setup(x => x.NodeLookup).Returns(nodeTracker.Object);
            graph.Setup(x => x.Type).Returns(GraphType.Directed);

            new Cluster(graph.Object).Name = null;
        }
    }
}