/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Edges;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Edges
{
    [TestFixture]
    public class ArrowSizeAttributeTests {

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Must_Throw_For_Value_Smaller_Than_0()
        {
            new ArrowSizeAttribute(-0.1);
        }

        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new ArrowSizeAttribute(0.5).ToDot(), "arrowsize=0.5");
        }
    }
}