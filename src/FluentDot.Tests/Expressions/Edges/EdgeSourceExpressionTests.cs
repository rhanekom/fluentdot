/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Edges;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeSourceExpressionTests {
        
        [Test]
        public void NodeWithName_Should_Select_Node_And_REturn_Expression() {
            var fromNode = new Mock<IGraphNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByName("b")).Returns(fromNode.Object);
            
            var edgeExpression = new EdgeSourceExpression(graph.Object).FromNodeWithName("b");
            Assert.IsNotNull(edgeExpression);
        }


        [Test]
        public void NodeWithName_Should_Add_Node_If_Node_Not_Found() {
            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            
            nodeLookup.Setup(x => x.GetNodeByName("b")).Returns((IGraphNode) null);
            new EdgeSourceExpression(graph.Object).FromNodeWithName("b");

            graph.Verify(x => x.AddNode(It.Is<IGraphNode>(n => n.Name == "b")));
        }



        [Test]
        public void NodeWithTag_Should_Lookup_Node_And_Return_Expression() {
            var fromNode = new Mock<IGraphNode>();
            
            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();


            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag(7)).Return(fromNode);
            
            var edgeExpression = new EdgeSourceExpression(graph).FromNodeWithTag(7);

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edgeExpression);
        }

        [Test]
        public void NodeWithTag_Should_Throw_Exception_If_Node_Not_Found() {
            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag(7)).Return(null);

            Assert.Throws<ArgumentException>(() => new EdgeSourceExpression(graph).FromNodeWithTag(7));
        }

        [Test]
        public void NewNode_Should_AddNode_To_Graph() {
            
            var graph = new Mock<IGraph>();
            
            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(
                Is.Matching<IGraphNode>(x => 
                                        x.Name == "a")
                );


            var edgeExpression = new EdgeSourceExpression(graph).FromNewNode("a");
            graph.VerifyAllExpectations();
            
            Assert.IsNotNull(edgeExpression);
        }

        [Test]
        public void NewNode_Should_AddNode_To_Graph_And_Apply_Configuration() {

            var graph = new Mock<IGraph>();

            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(
                Is.Matching<IGraphNode>(x =>
                                        x.Name == "a")
                );


            var edgeExpression = new EdgeSourceExpression(graph).FromNewNode("a", x => x.WithLabel("b"));
            graph.VerifyAllExpectations();

            Assert.IsNotNull(edgeExpression);
        }

        [Test]
        public void RecordWithName_Should_Select_Node_And_Return_Expression() {
            var fromNode = new Mock<IRecordNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            var elementTracker = new Mock<IElementTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByName("b")).Returns(fromNode.Object);

            fromNode.Setup(x => x.ElementTracker).Returns(elementTracker.Object);
            elementTracker.Setup(x => x.ContainsElement("c")).Returns(true);

            var edgeExpression = new EdgeSourceExpression(graph.Object).FromRecordWithName("b", "c");
            Assert.IsNotNull(edgeExpression);
        }


        [Test]
        public void RecordWithName_Should_Throw_Exception_If_Node_Not_Found() {
            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.SetupGet(x => x.GetNodeByName("b")).Returns((IGraphNode) null);

            Assert.Throws<ArgumentException>(() => new EdgeSourceExpression(graph.Object)
                .FromRecordWithName("b", "c"));
        }

        [Test]
        public void RecordWithTag_Should_Select_Node_And_Return_Expression() {
            var fromNode = new Mock<IRecordNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            var elementTracker = new Mock<IElementTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByTag("tag")).Returns(fromNode.Object);

            fromNode.Setup(x => x.ElementTracker).Returns(elementTracker.Object);
            elementTracker.Setup(x => x.ContainsElement("c")).Returns(true);

            var edgeExpression = new EdgeSourceExpression(graph.Object)
                .FromRecordWithTag("tag", "c");

            Assert.IsNotNull(edgeExpression);
        }


        [Test]
        public void RecordWithTag_Should_Throw_Exception_If_Node_Not_Found() {
            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByTag("tag")).Returns((IGraphNode) null);
            Assert.Throws<ArgumentException>(() => new EdgeSourceExpression(graph.Object).FromRecordWithTag("tag", "c"));
        }
    }
}