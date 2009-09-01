/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Entities;
using NUnit.Framework;

namespace FluentDot.Tests.Entities.Nodes
{
    [TestFixture]
    public class RecordGroupTests {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Must_Throw_If_Elements_Null()
        {
            new RecordGroup((IRecordItem[]) null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Must_Throw_If_No_Elements_Provided()
        {
            new RecordGroup(new IRecordElement[0]);
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output_With_Single_Element()
        {
            var group = new RecordGroup(new RecordElement("name"));
            Assert.AreEqual(group.ToDot(), "<name> name");
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output_With_Multiple_Elements() {
            var group = new RecordGroup(new RecordElement("name1"), new RecordElement("name2"));
            Assert.AreEqual(group.ToDot(), "<name1> name1|<name2> name2");
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output_With_Group() {
            var group = new RecordGroup(new RecordElement("name1"), new RecordElement("name2"));
            Assert.AreEqual(group.ToDot(), "<name1> name1|<name2> name2");
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output_With_Inverted_Group() {
            var group = new RecordGroup(new RecordElement("name1"), new RecordElement("name2")) { IsInverted = true };
            Assert.AreEqual(group.ToDot(), "{<name1> name1|<name2> name2}");
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output_With_Multiple_Groups() {
            var group = new RecordGroup(
                new RecordGroup(new RecordElement("name1"), new RecordElement("name2")),
                new RecordGroup(new RecordElement("name3"), new RecordElement("name4")) { IsInverted = true },
                new RecordGroup(new RecordElement("name5"), new RecordElement("name6"))
                );

            Assert.AreEqual(group.ToDot(), "<name1> name1|<name2> name2|{<name3> name3|<name4> name4}|<name5> name5|<name6> name6");
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output_With_Mixed_Groups() {
            var group = new RecordGroup(
                new RecordGroup(new RecordElement("name1"), new RecordGroup(new RecordElement("name2"), new RecordElement("name3")) { IsInverted = true }),
                new RecordGroup(new RecordElement("name4"), new RecordElement("name5"))
                );

            Assert.AreEqual(group.ToDot(), "<name1> name1|{<name2> name2|<name3> name3}|<name4> name4|<name5> name5");
        }

        [Test]
        public void AddElement_Adds_Element_To_Group()
        {
            var element = new RecordElement("b");

            var group = new RecordGroup();
            Assert.AreEqual(group.Elements.Count, 0);
            group.AddElement(element);
            Assert.AreEqual(group.Elements.Count, 1);
        }
    }
}