/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Graphs
{
    [TestFixture]
    public class JustificationTests {

        [Test]
        public void Constructor_Should_Save_Value()
        {
            Assert.AreEqual(new Justification("aa").Value, "aa");
        }

        [Test]
        public void ToDot_Should_Produce_Value()
        {
            Assert.AreEqual(new Justification("bbb").ToDot(), "bbb");
        }
    }
}