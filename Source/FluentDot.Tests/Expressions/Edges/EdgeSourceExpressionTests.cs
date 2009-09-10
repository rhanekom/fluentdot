/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using FluentDot.Expressions.Edges;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeSourceExpressionTests {
        
        [Test]
        public void NodeWithName_Should_Select_Node_And_REturn_Expression() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(fromNode);
            
            var edgeExpression = new EdgeSourceExpression(graph).NodeWithName("b");

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();
            
            Assert.IsNotNull(edgeExpression);
        }


        [Test]
        public void NodeWithName_Should_Add_Node_If_Node_Not_Found() {
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(Is.Matching<IGraphNode>(x => x.Name == "b"));

            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(null);
            new EdgeSourceExpression(graph).NodeWithName("b");

            graph.VerifyAllExpectations();
        }



        [Test]
        public void NodeWithTag_Should_Lookup_Node_And_Return_Expression() {
            var fromNode = MockRepository.GenerateMock<IGraphNode>();
            
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();


            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag(7)).Return(fromNode);
            
            var edgeExpression = new EdgeSourceExpression(graph).NodeWithTag(7);

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edgeExpression);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NodeWithTag_Should_Throw_Exception_If_Node_Not_Found() {
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag(7)).Return(null);

            new EdgeSourceExpression(graph).NodeWithTag(7);
        }

        [Test]
        public void NewNode_Should_AddNode_To_Graph() {
            
            var graph = MockRepository.GenerateMock<IGraph>();
            
            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(
                Is.Matching<IGraphNode>(x => 
                                        x.Name == "a")
                );


            var edgeExpression = new EdgeSourceExpression(graph).NewNode("a");
            graph.VerifyAllExpectations();
            
            Assert.IsNotNull(edgeExpression);
        }

        [Test]
        public void NewNode_Should_AddNode_To_Graph_And_Apply_Configuration() {

            var graph = MockRepository.GenerateMock<IGraph>();

            graph.Expect(x => x.AddNode(null))
                .IgnoreArguments()
                .Constraints(
                Is.Matching<IGraphNode>(x =>
                                        x.Name == "a")
                );


            var edgeExpression = new EdgeSourceExpression(graph).NewNode("a", x => x.WithLabel("b"));
            graph.VerifyAllExpectations();

            Assert.IsNotNull(edgeExpression);
        }

        [Test]
        public void RecordWithName_Should_Select_Node_And_Return_Expression() {
            var fromNode = MockRepository.GenerateMock<IRecordNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            var elementTracker = MockRepository.GenerateMock<IElementTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(fromNode);

            fromNode.Expect(x => x.ElementTracker).Return(elementTracker);
            elementTracker.Expect(x => x.ContainsElement("c")).Return(true);

            var edgeExpression = new EdgeSourceExpression(graph).RecordWithName("b", "c");

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edgeExpression);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void RecordWithName_Should_Throw_Exception_If_Node_Not_Found() {
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByName("b")).Return(null);
            new EdgeSourceExpression(graph).RecordWithName("b", "c");
        }

        [Test]
        public void RecordWithTag_Should_Select_Node_And_Return_Expression() {
            var fromNode = MockRepository.GenerateMock<IRecordNode>();

            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();
            var elementTracker = MockRepository.GenerateMock<IElementTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag("tag")).Return(fromNode);

            fromNode.Expect(x => x.ElementTracker).Return(elementTracker);
            elementTracker.Expect(x => x.ContainsElement("c")).Return(true);

            var edgeExpression = new EdgeSourceExpression(graph).RecordWithTag("tag", "c");

            graph.VerifyAllExpectations();
            nodeLookup.VerifyAllExpectations();

            Assert.IsNotNull(edgeExpression);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void RecordWithTag_Should_Throw_Exception_If_Node_Not_Found() {
            var graph = MockRepository.GenerateMock<IGraph>();
            var nodeLookup = MockRepository.GenerateMock<INodeTracker>();

            graph.Expect(x => x.NodeLookup).Return(nodeLookup);
            nodeLookup.Expect(x => x.GetNodeByTag("tag")).Return(null);
            new EdgeSourceExpression(graph).RecordWithTag("tag", "c");
        }
    }
}