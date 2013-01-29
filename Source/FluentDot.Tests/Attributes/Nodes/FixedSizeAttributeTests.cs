﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Nodes
{
    [TestFixture]
    public class FixedSizeAttributeTests
    {
        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            Assert.AreEqual(new FixedSizeAttribute(true).ToDot(), "fixedsize=true");
            Assert.AreEqual(new FixedSizeAttribute(false).ToDot(), "fixedsize=false");
        }
    }
}