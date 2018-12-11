/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Graphs;
using FluentDot.Expressions.Nodes;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class NodeCollectionModifiersExpressionTests {

        [Test]
        public void Add_Gets_Applied_To_Graph()
        {
            var graph = new Mock<IGraph>();

            var graphExpression = new GraphExpression<IGraph>(graph.Object);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph.Object, graphExpression);
            expression.Add(
                nodes =>
                    {
                        nodes.WithName("a");
                        nodes.WithName("b");
                    }
                );

            graph.Verify(x => x.AddNode(It.Is<IRecordNode>(n => n.Name == "a")));
            graph.Verify(x => x.AddNode(It.Is<IRecordNode>(n => n.Name == "b")));
        }

        [Test]
        public void Add_Returns_Parent_Expression()
        {
            var graph = new Mock<IGraph>();
            var graphExpression = new GraphExpression<IGraph>(graph.Object);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph.Object, graphExpression);

            var instance = expression.Add(nodes => nodes.WithName("a"));
            Assert.AreSame(instance, graphExpression);
        }

        [Test]
        public void AddRecord_Gets_Applied_To_Graph()
        {
            var graph = new Mock<IGraph>();

            var graphExpression = new GraphExpression<IGraph>(graph.Object);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph.Object, graphExpression);
            expression.AddRecord(
                records =>
                    {
                        records.WithName("a").WithElement("a1");
                        records.WithName("b").WithElement("b1");
                    });

            graph.Verify(x => x.AddNode(It.Is<IRecordNode>(n => n.Name == "a")));
            graph.Verify(x => x.AddNode(It.Is<IRecordNode>(n => n.Name == "b")));
        }

        [Test]
        public void AddRecord_Returns_Parent_Expression() {
            var graph = new Mock<IGraph>();
            var graphExpression = new GraphExpression<IGraph>(graph.Object);
            var expression = new NodeCollectionModifiersExpression<IGraphExpression>(graph.Object, graphExpression);

            var instance = expression.AddRecord(nodes => nodes.WithName("a"));
            Assert.AreSame(instance, graphExpression);
        }
    }
}