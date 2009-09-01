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
    public class HeightAttributeTests
    {
        [Test]
        public void ToDot_Should_Produce_Correct_Dot()
        {
            Assert.AreEqual(new HeightAttribute(0.2).ToDot(), "height=0.2");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Values_Less_Than_0_2_Should_Throw_Exception()
        {
            new HeightAttribute(0.01);
        }
    }
}