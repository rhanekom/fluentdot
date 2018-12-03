﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Shared
{
    [TestFixture]
    public class URLAttributeTests {

        [Test]
        public void ToDot_ShouldProduce_Correct_Output()
        {
            var attribute = new URLAttribute("http://www.google.com");
            Assert.AreEqual(attribute.ToDot(), "URL=\"http://www.google.com\"");
        }
    }
}