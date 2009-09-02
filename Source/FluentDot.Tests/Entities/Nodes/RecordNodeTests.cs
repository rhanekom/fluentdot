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
    public class RecordNodeTests {

        [Test]
        public void ToDot_Must_Produce_Correct_Output()
        {
            var recordGroup = new RecordGroup(new RecordElement("name"));
            Assert.AreEqual(
                new RecordNode("nodeName", recordGroup).ToDot(),
                "\"nodeName\" [shape=record, label=\"" + recordGroup.ToDot() + "\"]");
        }

        [Test]
        public void HasRoundedCorners_Changes_Shape_To_Mrecord() {
            var recordGroup = new RecordGroup(new RecordElement("name"));
            Assert.AreEqual(
                new RecordNode("nodeName", recordGroup) { HasRoundedCorners = true }.ToDot(),
                "\"nodeName\" [shape=Mrecord, label=\"" + recordGroup.ToDot() + "\"]");
        }
    }
}