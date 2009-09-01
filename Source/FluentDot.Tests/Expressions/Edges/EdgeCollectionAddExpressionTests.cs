/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Edges;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Edges
{
    [TestFixture]
    public class EdgeCollectionAddExpressionTests {

        [Test]
        public void From_Should_Never_Return_Null()
        {
            var graph = MockRepository.GenerateMock<IGraph>();
            Assert.IsNotNull(new EdgeCollectionAddExpression(graph).From);
        }
    }
}