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
    public class SubGraphCollectionAddExpressionTests
    {
        [Test]
        public void WithName_Should_Add_SubGraph_To_Graph()
        {
            var graph = new Mock<IGraph>();
            var edgeTracker = new Mock<IEdgeTracker>();
            var nodeTracker = new Mock<INodeTracker>();

            graph.Expect(x => x.EdgeLookup).Return(edgeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.NodeLookup).Return(nodeTracker).Repeat.AtLeastOnce();
            graph.Expect(x => x.Type).Return(GraphType.Directed);


            graph.Expect(x => x.AddSubGraph(null))
                .IgnoreArguments()
                .Constraints(
                Is.Matching<ISubGraph>(x => x.Name.Contains("bla"))
                );

            var expression = new SubGraphCollectionAddExpression(graph);
            expression.WithName("bla");

            graph.VerifyAllExpectations();
        }
    }
}
