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
    public class RecordElementTests {

        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            var element = new RecordElement("recordName") {Label = "recordLabel"};
            Assert.AreEqual(element.ToDot(), "<recordName> recordLabel");
        }

        [Test]
        public void ToDot_Should_Escape_Bad_Characters()
        {
            var element = new RecordElement("recordName") { Label = "<{record | | Label}>" };
            Assert.AreEqual(element.ToDot(), @"<recordName> \<\{record\ \|\ \|\ Label\}\>");
        }

        [Test]
        public void ToDot_Should_Use_Name_As_Label_If_No_Label_Specified() {
            var element = new RecordElement("recordName");
            Assert.AreEqual(element.ToDot(), @"<recordName> recordName");

            element.Label = String.Empty;
            Assert.AreEqual(element.ToDot(), @"<recordName> recordName");
        }

        [Test]
        public void IsInverted_Should_Surround_With_Curly_Braces()
        {
            var element = new RecordElement("recordName") { IsInverted = true };
            Assert.AreEqual(element.ToDot(), @"{<recordName> recordName}");
        }
    }
}