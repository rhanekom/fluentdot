/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Entities.Nodes
{
    [TestFixture]
    public class NodeTargetTests {

        [Test]
        public void ToDot_Should_Produce_Correct_Output_For_Normal_Nodes()
        {
            Assert.AreEqual(new NodeTarget(new GraphNode("a")).ToDot(), "\"a\"");
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output_For_Record_Nodes() {
            Assert.AreEqual(new NodeTarget(new RecordNode("a", new RecordGroup()), "b").ToDot(), "\"a\":\"b\"");
        }
    }
}