/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using FluentDot.Attributes.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Nodes
{
    [TestFixture]
    public class OrientationAttributeTests
    {
        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new OrientationAttribute(5).ToDot(), "orientation=5");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_Degrees_Smaller_Than_0()
        {
            new OrientationAttribute(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_When_Degrees_Larger_Than_360()
        {
            new OrientationAttribute(361);
        }
    }
}