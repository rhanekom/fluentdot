/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Text.RegularExpressions;
using FluentDot.Common;
using NUnit.Framework;

namespace FluentDot.Tests.Common
{
    [TestFixture]
    public class AbstractTypedEnumTests {

        [Test]
        public void Constructor_Should_Save_Value_Passed()
        {
            var e = new AbstractTypedEnum<int>(5);
            Assert.AreEqual(e.Value, 5);
        }

        [Test]
        public void Stuff()
        {
            Assert.IsTrue((Regex.Match("   #endregion  ", @"^(\ )*\#endregion(\ )*$", RegexOptions.Singleline).Success));

        }
    }
}