﻿/*
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
    public class ClusterCollectionModifiersExpressionTests {

        [Test]
        public void Add_Should_Apply_Action_And_Add_Cluster_To_Graph()
        {
            var graph = new Mock<IGraph>();
            var graphExpression = new Mock<IGraphExpression>();
            var edgeTracker = new Mock<IEdgeTracker>();
            var nodeTracker = new Mock<INodeTracker>();

            graph.Setup(x => x.EdgeLookup).Returns(edgeTracker.Object);
            graph.Setup(x => x.NodeLookup).Returns(nodeTracker.Object);
            
            graph.SetupGet(x => x.Type).Returns(GraphType.Directed);

            var expression = new ClusterCollectionModifiersExpression<IGraphExpression>(graph, graphExpression);
            expression.Add(x => x.WithName("bla"));

            graph.Verify(x => x.AddSubGraph(It.Is<ICluster>(c => c.Name.Contains("bla"))));
        }
    }
}