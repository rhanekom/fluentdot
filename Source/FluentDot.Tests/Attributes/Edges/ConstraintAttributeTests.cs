/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Edges;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Edges
{
    [TestFixture]
    public class ConstraintAttributeTests {

        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new ConstraintAttribute(true).ToDot(), "constraint=true");
            Assert.AreEqual(new ConstraintAttribute(false).ToDot(), "constraint=false");
        }
    }
}