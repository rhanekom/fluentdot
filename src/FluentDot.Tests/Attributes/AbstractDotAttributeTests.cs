/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using FluentDot.Attributes;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes
{
    [TestFixture]
    public class AbstractDotAttributeTests {

        #region Tests

        [Test]
        public void Constructor_Should_Set_Properties()
        {
            var attribute = new TestDotAttribute("name1", "value1", true);
            Assert.AreEqual(attribute.Name, "name1");
            Assert.AreEqual(attribute.Value, "value1");
        }

        [Test]
        public void ToDot_Should_Generate_Dot_Correctly()
        {
            var attributeEnclosedInQuotes = new TestDotAttribute("name1", "value1", true);
            Assert.AreEqual(attributeEnclosedInQuotes.ToDot(), "name1=\"value1\"");

            var attributeNotEnclosedInQuotes = new TestDotAttribute("name2", "value2", false);
            Assert.AreEqual(attributeNotEnclosedInQuotes.ToDot(), "name2=value2");
        }

        [Test]
        public void Constructor_Should_Throw_For_Null_Name()
        {
            Assert.Throws<ArgumentException>(() => new TestDotAttribute(null, "", true));
        }

        [Test]
        public void Constructor_Should_Throw_For_Empty_Name() {
            Assert.Throws<ArgumentException>(() => new TestDotAttribute("", "", true));
        }

        [Test]
        public void Constructor_Should_Throw_For_Null_Value() {
            Assert.Throws<ArgumentException>(() => new TestDotAttribute("aa", null, true));
        }

        #endregion

        #region Private Members

        private class TestDotAttribute : AbstractDotAttribute<object>
        {
            public TestDotAttribute(string name, object value, bool encloseInQuotes) : base(name, value, encloseInQuotes)
            {
                
            }
        }

        #endregion
    }
}