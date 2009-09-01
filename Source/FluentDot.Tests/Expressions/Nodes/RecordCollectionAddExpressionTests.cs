/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class RecordCollectionAddExpressionTests {

        [Test]
        public void WithName_Sets_Name_And_Adds_Node_To_Graph()
        {
            var graph = new DirectedGraph();
            var expression = new RecordCollectionAddExpression(graph);
            Assert.IsNotNull(expression.WithName("name"));

            var node = graph.NodeLookup.GetNodeByName("name");
            Assert.IsNotNull(node);
            Assert.AreEqual(node.Name, "name");
        }
    }
}