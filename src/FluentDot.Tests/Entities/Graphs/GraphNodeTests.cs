/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes;
using FluentDot.Entities.Nodes;
using NUnit.Framework;
using System;
using Moq;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class GraphNodeTests {

        [Test]
        public void Constructor_Should_Set_Name()
        {
            Assert.AreEqual(new GraphNode("bb").Name, "bb");
        }

        [Test]
        public void Constructor_Name_Should_Throw_If_Set_To_Empty()
        {
            Assert.Throws<ArgumentException>(() => new GraphNode(String.Empty));
        }
        
        [Test]
        public void Constructor_Name_Should_Throw_If_Set_To_Null() {
            Assert.Throws<ArgumentException>(() => new GraphNode(null));
        }

        [Test]
        public void ToDot_Should_Output_Name()
        {
            Assert.AreEqual(new GraphNode("ff").ToDot(), "\"ff\"");
        }

        [Test]
        public void ToDot_Should_Output_Name_With_Attributes() {
            var node = new GraphNode("ff");

            var attribute = new Mock<IDotAttribute>();
            attribute.Setup(x => x.ToDot()).Returns("att=custom");
            node.Attributes.AddAttribute(attribute.Object);

            Assert.AreEqual(node.ToDot(), "\"ff\" [att=custom]");
        }
    }
}