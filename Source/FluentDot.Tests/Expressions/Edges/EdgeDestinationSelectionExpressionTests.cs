/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Shared;
using FluentDot.Entities;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Edges;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeDestinationSelectionExpressionTests {
        
        [Test]
        public void NodeWithName_Should_Add_Node_To_Graph_And_Return_Configuration_Options()
        {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();
            var toNode = MockRepository.GenerateMock<IGraphNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(toNode);

            IEdge edge = null;

            graph.Expect(x => x.AddEdge(null))
                .IgnoreArguments()
                .WhenCalled(x => edge = (IEdge) x.Arguments[0]);

            var edgeExpression = new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).NodeWithName("b");

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);

            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 0);
            edgeExpression.WithLabel("b");
            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 1);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NodeWithName_Should_Throw_Exception_If_Node_Not_Found() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            
            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(null);
            new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).NodeWithName("b");
        }



        [Test]
        public void NodeWithTag_Should_Add_Node_To_Graph_And_Return_Configuration_Options() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();
            var toNode = MockRepository.GenerateMock<IGraphNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();


            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag(7)).Return(toNode);

            IEdge edge = null;

            graph.Expect(x => x.AddEdge(null))
                .IgnoreArguments()
                .WhenCalled(x => edge = (IEdge)x.Arguments[0]);

            var edgeExpression = new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).NodeWithTag(7);

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);

            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 0);
            edgeExpression.WithLabel("b");
            Assert.AreEqual(edge.Attributes.CurrentAttributes.Count, 1);
        }



        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NodeWithTag_Should_Throw_Exception_If_Node_Not_Found() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            
            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag(7)).Return(null);
            
            new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).NodeWithTag(7);
        }

        [Test]
        public void NewNode_Should_Add_NewNode_To_Graph_And_Return_Configuration_Options() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();
            
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<ILookupNodes>();
            
            IEdge edge = null;

            graph.Expect(x => x.AddEdge(null))
                .IgnoreArguments()
                .WhenCalled(x => edge = (IEdge)x.Arguments[0]);

            var edgeExpression = new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph)
                .NewNode("a");

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node.Name, "a");
        }

        [Test]
        public void NewNode_Should_Add_NewNode_To_Graph_And_Apply_Node_Configuraiton() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<ILookupNodes>();

            IEdge edge = null;

            graph.Expect(x => x.AddEdge(null))
                .IgnoreArguments()
                .WhenCalled(x => edge = (IEdge)x.Arguments[0]);

            var edgeExpression = new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph)
                .NewNode("a", x => x.WithLabel("aa"));

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node.Name, "a");

            Assert.AreEqual(edge.To.Node.Attributes.CurrentAttributes.Count, 1);
            Assert.IsAssignableFrom(typeof(LabelAttribute), edge.To.Node.Attributes.CurrentAttributes[0]);
        }


        [Test]
        public void RecordWithName_Should_Add_Node_To_Graph_And_Return_Configuration_Options() {
            var fromNode = MockRepository.GenerateMock<IRecordNode>();
            var toNode = MockRepository.GenerateMock<IRecordNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            var elementTracker = MockRepository.GenerateMock<IElementTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(toNode);

            IEdge edge = null;

            graph.Expect(x => x.AddEdge(null))
                .IgnoreArguments()
                .WhenCalled(x => edge = (IEdge)x.Arguments[0]);

            toNode.Expect(x => x.ElementTracker).Return(elementTracker);
            elementTracker.Expect(x => x.ContainsElement("c")).Return(true);

            var edgeExpression = new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).RecordWithName("b", "c");

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();
            elementTracker.VerifyAllExpectations();

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void RecordWithName_Should_Throw_If_Node_Was_Not_Found() {
            var fromNode = MockRepository.GenerateMock<IRecordNode>();
            var toNode = MockRepository.GenerateMock<IRecordNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            var elementTracker = MockRepository.GenerateMock<IElementTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(toNode);

            toNode.Expect(x => x.ElementTracker).Return(elementTracker);
            elementTracker.Expect(x => x.ContainsElement("c")).Return(false);

            new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).RecordWithName("b", "c");
        }


        [Test]
        public void RecordWithTag_Should_Add_Node_To_Graph_And_Return_Configuration_Options() {
            var fromNode = MockRepository.GenerateMock<IRecordNode>();
            var toNode = MockRepository.GenerateMock<IRecordNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            var elementTracker = MockRepository.GenerateMock<IElementTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag("tag")).Return(toNode);

            IEdge edge = null;

            graph.Expect(x => x.AddEdge(null))
                .IgnoreArguments()
                .WhenCalled(x => edge = (IEdge)x.Arguments[0]);

            toNode.Expect(x => x.ElementTracker).Return(elementTracker);
            elementTracker.Expect(x => x.ContainsElement("c")).Return(true);

            var edgeExpression = new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).RecordWithTag("tag", "c");

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();
            elementTracker.VerifyAllExpectations();

            Assert.IsNotNull(edge);
            Assert.IsNotNull(edgeExpression);

            Assert.AreSame(edge.From.Node, fromNode);
            Assert.AreSame(edge.To.Node, toNode);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void RecordWithTag_Should_Throw_If_Node_Was_Not_Found() {
            var fromNode = MockRepository.GenerateMock<IRecordNode>();
            var toNode = MockRepository.GenerateMock<IRecordNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            var elementTracker = MockRepository.GenerateMock<IElementTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag("tag")).Return(toNode);

            toNode.Expect(x => x.ElementTracker).Return(elementTracker);
            elementTracker.Expect(x => x.ContainsElement("c")).Return(false);

            new EdgeDestinationSelectionExpression(new NodeTarget(fromNode), graph).RecordWithTag("tag", "c");
        }
       
    }
}