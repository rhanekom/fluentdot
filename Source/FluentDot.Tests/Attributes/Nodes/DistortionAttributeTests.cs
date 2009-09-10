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
    public class DistortionAttributeTests
    {
        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new DistortionAttribute(50.2).ToDot(), "distortion=50.2");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_If_Value_Less_Than_Minus_100()
        {
            new DistortionAttribute(-100.1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_If_Value_Larger_Than_100()
        {
            new DistortionAttribute(100.1);
        }
    }
}
