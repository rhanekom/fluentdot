/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using FluentDot.Attributes.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Shared
{
    [TestFixture]
    public class ColorAttributeTests {

        [Test]
        public void Dot_Should_Produce_Correct_Ouput()
        {
            Assert.AreEqual(new ColorAttribute(Color.Black).ToDot(), "color=\"#000000\"");
            Assert.AreEqual(new ColorAttribute(Color.Red).ToDot(), "color=\"#ff0000\"");
            Assert.AreEqual(new ColorAttribute(Color.Transparent).ToDot(), "color=\"transparent\"");
        }
    }
}