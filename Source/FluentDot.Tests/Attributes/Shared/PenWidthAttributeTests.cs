﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Shared {
    
    [TestFixture]
    public class PenWidthAttributeTests {

        [Test]
        public void ToDot_Produces_Correct_Outpu()
        {
            Assert.AreEqual(new PenWidthAttribute(1.2).ToDot(), "penwidth=1.2");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_For_Value_Less_Than_0()
        {
            new PenWidthAttribute(-0.1);
        }
    }
}
