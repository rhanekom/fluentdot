/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Graphs {
    
    [TestFixture]
    public class DefaultsExpressionTests {

        [Test]
        public void Nodes_Action_Should_Add_Template_As_Defaults_To_Graph()
        {
            var graph = new DirectedGraph();

            Assert.IsNull(graph.NodeDefaults);

            var graphExpression = new GraphExpression<IDirectedGraph>(graph);

            var expression = new DefaultsExpression(graphExpression, graph);
            expression.ForNodes.Are(x => x.WithLabel("label"));

            Assert.IsNotNull(graph.NodeDefaults);
            Assert.AreEqual(graph.NodeDefaults.AttributeCount, 1);
        }

        [Test]
        public void Edges_Action_Should_Add_Template_As_Defaults_To_Graph()
        {
            var graph = new DirectedGraph();
            var graphExpression = new GraphExpression<IDirectedGraph>(graph);

            Assert.IsNull(graph.EdgeDefaults);

            var expression = new DefaultsExpression(graphExpression, graph);
            expression.ForEdges.Are(x => x.WithLabel("label"));

            Assert.IsNotNull(graph.EdgeDefaults);
            Assert.AreEqual(graph.EdgeDefaults.AttributeCount, 1);
        }
    }
}
