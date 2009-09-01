/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Text.RegularExpressions;
using FluentDot.Entities.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class UndirectedGraphTests {

        [Test]
        public void ToDot_Should_Return_DiGraph_Entity() {
            var graph = new UndirectedGraph { Name = "a" };
            var dot = graph.ToDot();
            
            Assert.IsTrue(Regex.Match(dot, @"^graph a \{[^}]*\}$", RegexOptions.Multiline).Success);
        }
    }
}