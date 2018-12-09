/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Shared;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Edges;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeDestinationSelectionExpressionTests {
        
        [Test]
        public void NodeWithName_Should_Add_Node_To_Graph_And_Return_Configuration_Options()
        {
            var fromNode = new Mock<IGraphNode>();
            var toNode = new Mock<IGraphNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByName("b")).Returns(toNode.Object);

            IEdge edge = null;

            graph.Setup(x => x.AddEdge(It.IsAny<IEdge>()))
                .Callback<IEdge>(x => edge = x);

            var edgeExpression = new EdgeDestinationSelectionExpression(
                new NodeTarget(fromNode.Object), graph.Object).ToNodeWithName("b");

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);

            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 0);
            edgeExpression.WithLabel("b");
            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 1);
        }


        [Test]
        public void NodeWithName_Should_AddNode_If_Node_Not_Found() {
            var fromNode = new Mock<IGraphNode>();
            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            
            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            graph.Setup(x => x.AddNode(It.Is<IGraphNode>(n => n.Name == "b")));

            nodeLookup.Setup(x => x.GetNodeByName("b")).Returns((IGraphNode) null);
            new EdgeDestinationSelectionExpression(new NodeTarget(fromNode.Object), graph.Object)
                .ToNodeWithName("b");
        }



        [Test]
        public void NodeWithTag_Should_Add_Node_To_Graph_And_Return_Configuration_Options() {
            var fromNode = new Mock<IGraphNode>();
            var toNode = new Mock<IGraphNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();


            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByTag(7)).Returns(toNode.Object);

            IEdge edge = null;

            graph.Setup(x => x.AddEdge(It.IsAny<IEdge>()))
                .Callback<IEdge>(x => edge = x);

            var edgeExpression = new EdgeDestinationSelectionExpression(
                new NodeTarget(fromNode.Object), graph.Object).ToNodeWithTag(7);
            
            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);

            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 0);
            edgeExpression.WithLabel("b");
            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 1);
        }



        [Test]
        public void NodeWithTag_Should_Throw_Exception_If_Node_Not_Found() {
            var fromNode = new Mock<IGraphNode>();
            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            
            graph.SetupGet(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByTag(7)).Returns((IGraphNode) null);
            
            Assert.Throws<ArgumentException>(() => new EdgeDestinationSelectionExpression(
                new NodeTarget(fromNode.Object), graph.Object).ToNodeWithTag(7));
        }

        [Test]
        public void NewNode_Should_Add_NewNode_To_Graph_And_Return_Configuration_Options() {
            var fromNode = new Mock<IGraphNode>();
            
            var graph = new Mock<IGraph>();
            
            IEdge edge = null;

            graph.Setup(x => x.AddEdge(It.IsAny<IEdge>()))
                .Callback<IEdge>(x => edge = x);

            var edgeExpression = new EdgeDestinationSelectionExpression(
                    new NodeTarget(fromNode.Object), graph.Object)
                .ToNewNode("a");
            
            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node.Name, "a");
        }

        [Test]
        public void NewNode_Should_Add_NewNode_To_Graph_And_Apply_Node_Configuraiton() {
            var fromNode = new Mock<IGraphNode>();

            var graph = new Mock<IGraph>();

            IEdge edge = null;

            graph.Setup(x => x.AddEdge(It.IsAny<IEdge>()))
                .Callback<IEdge>(x => edge = x);

            var edgeExpression = new EdgeDestinationSelectionExpression(new NodeTarget(fromNode.Object), graph.Object)
                .ToNewNode("a", x => x.WithLabel("aa"));
            
            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node.Name, "a");

            Assert.AreEqual(edge.To.Node.Attributes.CurrentAttributes.Count, 1);
            Assert.IsAssignableFrom(typeof(LabelAttribute), edge.To.Node.Attributes.CurrentAttributes[0]);
        }


        [Test]
        public void RecordWithName_Should_Add_Node_To_Graph_And_Return_Configuration_Options() {
            var fromNode = new Mock<IRecordNode>();
            var toNode = new Mock<IRecordNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            var elementTracker = new Mock<IElementTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByName("b")).Returns(toNode.Object);

            IEdge edge = null;

            graph.Setup(x => x.AddEdge(It.IsAny<IEdge>()))
                .Callback<IEdge>(x => edge = x);

            toNode.Setup(x => x.ElementTracker).Returns(elementTracker.Object);
            elementTracker.Setup(x => x.ContainsElement("c")).Returns(true);

            var edgeExpression = new EdgeDestinationSelectionExpression(
                new NodeTarget(fromNode.Object), graph.Object).ToRecordWithName("b", "c");
            
            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);
        }

        [Test]
        public void RecordWithName_Should_Throw_If_Node_Was_Not_Found() {
            var fromNode = new Mock<IRecordNode>();
            var toNode = new Mock<IRecordNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            var elementTracker = new Mock<IElementTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByName("b")).Returns(toNode.Object);

            toNode.Setup(x => x.ElementTracker).Returns(elementTracker.Object);
            elementTracker.Setup(x => x.ContainsElement("c")).Returns(false);

            Assert.Throws<ArgumentException>(() => new EdgeDestinationSelectionExpression(
                new NodeTarget(fromNode.Object), graph.Object).ToRecordWithName("b", "c"));
        }


        [Test]
        public void RecordWithTag_Should_Add_Node_To_Graph_And_Return_Configuration_Options() {
            var fromNode = new Mock<IRecordNode>();
            var toNode = new Mock<IRecordNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            var elementTracker = new Mock<IElementTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByTag("tag")).Returns(toNode.Object);

            IEdge edge = null;

            graph.Setup(x => x.AddEdge(It.IsAny<IEdge>()))
                .Callback<IEdge>(x => edge = x);

            toNode.Setup(x => x.ElementTracker).Returns(elementTracker.Object);
            elementTracker.Setup(x => x.ContainsElement("c")).Returns(true);

            var edgeExpression = new EdgeDestinationSelectionExpression(
                new NodeTarget(fromNode.Object), graph.Object).ToRecordWithTag("tag", "c");

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);
        }

        [Test]
        public void RecordWithTag_Should_Throw_If_Node_Was_Not_Found() {
            var fromNode = new Mock<IRecordNode>();
            var toNode = new Mock<IRecordNode>();

            var graph = new Mock<IGraph>();
            var nodeLookup = new Mock<INodeTracker>();
            var elementTracker = new Mock<IElementTracker>();

            graph.Setup(x => x.NodeLookup).Returns(nodeLookup.Object);
            nodeLookup.Setup(x => x.GetNodeByTag("tag")).Returns(toNode.Object);

            toNode.Setup(x => x.ElementTracker).Returns(elementTracker.Object);
            elementTracker.Setup(x => x.ContainsElement("c")).Returns(false);

            Assert.Throws<ArgumentException>(() => new EdgeDestinationSelectionExpression(
                new NodeTarget(fromNode.Object), graph.Object).ToRecordWithTag("tag", "c"));
        }
    }
}