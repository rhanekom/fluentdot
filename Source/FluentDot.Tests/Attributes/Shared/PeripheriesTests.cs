/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Shared {
    
    [TestFixture]
    public class PeripheriesTests {

        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new PeripheriesAttribute(2).ToDot(), "peripheries=2");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_If_Value_Less_Than_0()
        {
            new PeripheriesAttribute(-1);
        }
    }
}
