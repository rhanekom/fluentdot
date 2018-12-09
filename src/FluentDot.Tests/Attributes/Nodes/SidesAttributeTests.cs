﻿/*
 Copyright 2012 Riaan Hanekom

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
    public class SidesAttributeTests
    {
        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new SidesAttribute(4).ToDot(), "sides=4");
        }

        [Test]
        public void Constructor_Should_Throw_If_Value_Less_Than_0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SidesAttribute(-1));
        }
    }
}
