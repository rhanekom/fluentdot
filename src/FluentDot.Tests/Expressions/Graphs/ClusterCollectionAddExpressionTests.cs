/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Graphs;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Graphs
{
    [TestFixture]
    public class ClusterCollectionAddExpressionTests
    {
        [Test]
        public void WithName_Should_Add_Cluster_To_Graph()
        {
            var graph = new Mock<IGraph>();
            var edgeTracker = new Mock<IEdgeTracker>();
            var nodeTracker = new Mock<INodeTracker>();

            graph.Setup(x => x.EdgeLookup).Returns(edgeTracker.Object);
            graph.Setup(x => x.NodeLookup).Returns(nodeTracker.Object);
            graph.Setup(x => x.Type).Returns(GraphType.Directed);

            var expression = new ClusterCollectionAddExpression(graph.Object);
            expression.WithName("bla");

            graph.Verify(x => x.AddSubGraph(It.Is<ICluster>(c => c.Name.Contains("bla"))));
        }
    }
}
