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

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class SubGraphTests
    {

        [Test]
        public void Constructor_Saves_Graph_Type()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.Type).Return(GraphType.Directed);

            Assert.AreEqual(new SubGraph(graph).Type, GraphType.Directed);
        }
    }
}