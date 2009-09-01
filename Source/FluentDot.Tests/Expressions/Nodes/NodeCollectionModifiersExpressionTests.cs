/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Graphs;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class NodeCollectionModifiersExpressionTests {

        [Test]
        public void Add_Gets_Applied_To_Graph()
        {
            var graph = MockRepository.GenerateMock<IGraph>();

            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(Is.Matching<IGraphNode>(x => x.Name == "a"));

            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(Is.Matching<IGraphNode>(x => x.Name == "b"));

            var graphExpression = new GraphExpression<IGraph>(graph);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph, graphExpression);
            expression.Add(
                nodes =>
                    {
                        nodes.WithName("a");
                        nodes.WithName("b");
                    }
                );

            graph.VerifyAllExpectations();
        }

        [Test]
        public void Add_Returns_Parent_Expression()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var graphExpression = new GraphExpression<IGraph>(graph);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph, graphExpression);

            var instance = expression.Add(nodes => nodes.WithName("a"));
            Assert.AreSame(instance, graphExpression);
        }

        [Test]
        public void AddRecord_Gets_Applied_To_Graph()
        {
            var graph = MockRepository.GenerateMock<IGraph>();

            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(Is.Matching<IRecordNode>(x => x.Name == "a"));

            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(Is.Matching<IRecordNode>(x => x.Name == "b"));

            var graphExpression = new GraphExpression<IGraph>(graph);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph, graphExpression);
            expression.AddRecord(
                records =>
                    {
                        records.WithName("a").WithElement("a1");
                        records.WithName("b").WithElement("b1");
                    });

            graph.VerifyAllExpectations();
        }

        [Test]
        public void AddRecord_Returns_Parent_Expression() {
            var graph = MockRepository.GenerateMock<IGraph>();
            var graphExpression = new GraphExpression<IGraph>(graph);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph, graphExpression);

            var instance = expression.AddRecord(nodes => nodes.WithName("a"));
            Assert.AreSame(instance, graphExpression);
        }
    }
}