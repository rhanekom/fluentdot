/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Graphs;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentDot.Tests.Expressions.Graphs
{
    [TestFixture]
    public class ClusterCollectionAddExpressionTests
    {
        [Test]
        public void WithName_Should_Add_Cluster_To_Graph()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var edgeTracker = MockRepository.GenerateMock<IEdgeTracker>();
            var nodeTracker = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.Type).Return(GraphType.Directed);


            graph.Expect(x => x.AddCluster(null))
                .IgnoreArguments()
                .Constraints(
                Is.Matching<ICluster>(x => x.Name.Contains("bla"))
                );

            var expression = new ClusterCollectionAddExpression(graph);
            expression.WithName("bla");

            graph.VerifyAllExpectations();
        }
    }
}
