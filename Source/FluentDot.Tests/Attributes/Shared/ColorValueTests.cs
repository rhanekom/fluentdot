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
    public class ColorValueTests {

        [Test]
        public void ToDot_Should_Convert_Color_To_Hex()
        {
            Assert.AreEqual(new ColorValue(Color.White).ToDot(), "#ffffff");
            Assert.AreEqual(new ColorValue(Color.Red).ToDot(), "#ff0000");
            Assert.AreEqual(new ColorValue(Color.Blue).ToDot(), "#0000ff");
            Assert.AreEqual(new ColorValue(Color.Black).ToDot(), "#000000");
        }

        [Test]
        public void ToDot_Should_Convert_Transparet_To_String() {
            Assert.AreEqual(new ColorValue(Color.Transparent).ToDot(), "transparent");
        }
    }
}