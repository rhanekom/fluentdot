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
    public class LabelAngleAttributeTests
    {
        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new LabelAngleAttribute(25.9).ToDot(), "labelangle=25.9");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_If_Angle_Less_Than_Minus_180()
        {
            new LabelAngleAttribute(-181);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_If_Angle_Greater_Than_180()
        {
            new LabelAngleAttribute(181);
        }
    }
}