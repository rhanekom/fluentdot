/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Conventions;
using FluentDot.Entities;
using FluentDot.Entities.Edges;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Edges;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace FluentDot.Tests.Conventions
{
    [TestFixture]
    public class ConventionTrackerTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddConvention_Node_Should_Throw_Exception_If_Convention_Is_Null()
        {
            new ConventionTracker().AddConvention((INodeConvention) null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddConvention_Edge_Should_Throw_Exception_If_Convention_Is_Null()
        {
            new ConventionTracker().AddConvention((IEdgeConvention)null);
        }

        [Test]
        public void ApplyConventions_Node_Should_Apply_Conventions()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<INodeConvention>();
            var graphNode = new GraphNode("a");
            var nodeInfo = new NodeInfo(graphNode.Name, graphNode.Tag);

            convention.Expect(x => x.ShouldApply(nodeInfo))
                .IgnoreArguments()
                .Constraints(Is.Matching<INodeInfo>(x => x.Name == "a"))
                .Return(true)
                .Repeat.Once();

            convention.Expect(x => x.Apply(null, null)).IgnoreArguments()
                .Constraints(Is.Matching<INodeInfo>(x => x.Name == graphNode.Name && x.Tag == graphNode.Tag), Is.Matching<INodeExpression>(x => x != null))
                .Repeat.Once();
            
            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(graphNode);

            convention.VerifyAllExpectations();
        }

        [Test]
        public void ApplyConventions_Node_Should_Not_Apply_Conventions_When_Should_Apply_Is_False()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<INodeConvention>();
            var graphNode = new GraphNode("a");
            var nodeInfo = new NodeInfo(graphNode.Name, graphNode.Tag);

            convention.Expect(x => x.ShouldApply(nodeInfo))
                .IgnoreArguments()
                .Return(false)
                .Repeat.Once();

            convention.Expect(x => x.Apply(null, null))
                .IgnoreArguments()
                .Repeat.Never();
                
            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(graphNode);

            convention.VerifyAllExpectations();
        }

        [Test]
        public void ApplyConventions_Edge_Should_Apply_Conventions()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<IEdgeConvention>();
            var fromNode = new GraphNode("a");
            var toNode = new GraphNode("b");
            var edgeInfo = new EdgeInfo(new NodeInfo(fromNode.Name, null), new NodeInfo(toNode.Name, null), null);

            convention.Expect(x => x.ShouldApply(edgeInfo))
                .IgnoreArguments()
                .Constraints(Is.Matching<IEdgeInfo>(x => x.FromNode.Name == "a" && x.ToNode.Name == "b"))
                .Return(true)
                .Repeat.Once();

            convention.Expect(x => x.Apply(null, null)).IgnoreArguments()
                .Constraints(
                    Is.Matching<IEdgeInfo>(x => 
                        x.Tag == edgeInfo.Tag && 
                        x.FromNode.Name == edgeInfo.FromNode.Name &&
                        x.ToNode.Name == edgeInfo.ToNode.Name
                    ), Is.Matching<IEdgeExpression>(x => x != null))
                .Repeat.Once();

            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(new DirectedEdge(new NodeTarget(fromNode), new NodeTarget(toNode)));
            convention.VerifyAllExpectations();
        }

        [Test]
        public void ApplyConventions_Edge_Should_Not_Apply_Conventions_When_Should_Apply_Is_False()
        {
            var conventionTracker = new ConventionTracker();
            var convention = MockRepository.GenerateMock<IEdgeConvention>();
            var fromNode = new GraphNode("a");
            var toNode = new GraphNode("b");
            var edgeInfo = new EdgeInfo(new NodeInfo(fromNode.Name, null), new NodeInfo(toNode.Name, null), null);

            convention.Expect(x => x.ShouldApply(edgeInfo))
                .IgnoreArguments()
                .Return(false)
                .Repeat.Once();

            convention.Expect(x => x.Apply(null, null))
                .IgnoreArguments()
                .Repeat.Never();

            conventionTracker.AddConvention(convention);
            conventionTracker.ApplyConventions(new DirectedEdge(new NodeTarget(fromNode), new NodeTarget(toNode)));
            convention.VerifyAllExpectations();
        }
    }
}
