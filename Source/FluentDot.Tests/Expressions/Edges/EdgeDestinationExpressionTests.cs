/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using FluentDot.Entities;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Edges;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeDestinationExpressionTests {

        [Test]
        public void To_Should_not_Return_Null_Expression()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            var fromNode = MockRepository.GenerateMock<IGraphNode>();

            Assert.IsNotNull(new EdgeDestinationExpression(new NodeTarget(fromNode), graph).To);
        }
    }
}