/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Configuration;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests {
    
    [TestFixture]
    public class FluentlyTests {

        [Test]
        public void CreateDirectedGraph_Should_Return_Directed_Graph()
        {
            var graph = Fluently.CreateDirectedGraph();
            Assert.IsNotNull(graph);
            IDirectedGraph graphInstance =  ((GraphExpression<IDirectedGraph>) graph).Graph;
            Assert.IsNotNull(graphInstance);
        }

        [Test]
        public void CreateUndirectedGraph_Should_Return_Undirected_Graph() {
            var graph = Fluently.CreateUndirectedGraph();
            Assert.IsNotNull(graph);

            IUndirectedGraph graphInstance = ((GraphExpression<IUndirectedGraph>)graph).Graph;
            Assert.IsNotNull(graphInstance);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Configure_Should_Throw_If_Null_Is_Passed()
        {
            Fluently.Configure(null);
        }

        [Test]
        public void Configure_Should_Set_Global_Configuration_Values() {
            Fluently.Configure(x =>
                                   {
                                       x.DotFilePath.Is("c:\\a");
                                       x.DotProcessTimeout.Is(5000);
                                   }
            );

            Assert.AreEqual(GlobalConfiguration.Instance.DotExecutableLocation, "c:\\a");
            Assert.AreEqual(GlobalConfiguration.Instance.DotProcessTimeout, 5000);
        }
    }
}
