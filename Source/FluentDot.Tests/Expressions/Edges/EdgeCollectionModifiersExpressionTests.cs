/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Linq;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeCollectionModifiersExpressionTests {

        [Test]
        public void Add_Gets_Applied_To_Graph() {
            var graph = new DirectedGraph();

            var a = new GraphNode("a");
            var b = new GraphNode("b");
            var c = new GraphNode("c");
            var d = new GraphNode("d");

            graph.AddNode(a);
            graph.AddNode(b);
            graph.AddNode(c);
            graph.AddNode(d);

            var graphExpression = new GraphExpression<IDirectedGraph>(graph);
            var expression = new EdgeCollectionModifiersExpression<IGraphExpression>(graph, graphExpression);

            expression.Add(
                edges =>
                    {
                        edges.FromNodeWithName("a").ToNodeWithName("b");
                        edges.FromNodeWithName("c").ToNodeWithName("d");
                    }
                );

            Assert.AreEqual(graph.Edges.Count(), 2);

            var edge1 = graph.Edges.First();
            Assert.AreEqual(edge1.From.Node, a);
            Assert.AreEqual(edge1.To.Node, b);

            var edge2 = graph.Edges.Skip(1).First();
            Assert.AreEqual(edge2.From.Node, c);
            Assert.AreEqual(edge2.To.Node, d);
        }

        [Test]
        public void Add_Returns_Parent_Expression() {
            var graph = new UndirectedGraph();

            var a = new GraphNode("a");
            var b = new GraphNode("b");

            graph.AddNode(a);
            graph.AddNode(b);

            var graphExpression = new GraphExpression<IUndirectedGraph>(graph);
            var expression = new EdgeCollectionModifiersExpression<IGraphExpression>(graph, graphExpression);
            
            var instance = expression.Add(edges => edges.FromNodeWithName("a").ToNodeWithName("b"));
            Assert.AreSame(instance, graphExpression);
        }
    }
}