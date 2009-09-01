/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;
using NUnit.Framework;

namespace FluentDot.Tests.Common
{
    [TestFixture]
    public class StringEnumTests {

        [Test]
        public void Constructor_Should_Save_Value_Passed() {
            var e = new StringEnum("33f");
            Assert.AreSame(e.Value, "33f");
        }
    }
}