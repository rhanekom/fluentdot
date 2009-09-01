/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class ClusterTests {

        [Test]
        public void Constructor_Saves_Graph_Type()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.Type).Return(GraphType.Directed);

            Assert.AreEqual(new Cluster(graph).Type, GraphType.Directed);
        }
       

        [Test]
        public void Name_Should_Prepend_Cluster_To_Given_Name()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.Type).Return(GraphType.Directed);

            Assert.IsTrue(new Cluster(graph).Name.StartsWith("cluster"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_Should_Throw_For_Null()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.Type).Return(GraphType.Directed);

            new Cluster(graph).Name = null;
        }
    }
}