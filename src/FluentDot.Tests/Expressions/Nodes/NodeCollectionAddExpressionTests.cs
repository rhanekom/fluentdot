﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Nodes;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class NodeCollectionAddExpressionTests {

        [Test]
        public void CreateNode_Should_Add_Node_To_Graph() {
            var graph = new Mock<IGraph>();

            var expression = new NodeCollectionAddExpression(graph.Object);

            expression.WithName("a");

            graph.Verify(x => x.AddNode(It.Is<IGraphNode>(n => n.Name == "a" && n.Attributes.CurrentAttributes.Count == 0)));
        }

        [Test]
        public void CreateNode_Should_Add_Node_To_Graph_And_Apply_Custom_Configuration() {
            var graph = new Mock<IGraph>();

            var expression = new NodeCollectionAddExpression(graph);
            expression.WithName("a").WithLabel("label");
            
            graph.Verify(x => x.AddNode(It.Is<IGraphNode>(n => n.Name == "a")));
        }
    }
}