/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Execution;
using NUnit.Framework;

namespace FluentDot.Tests.Execution {
    
    [TestFixture]
    public class InputFileParameterTests {

        [Test]
        public void ToCommandLine_Should_Wrap_FileName_In_Quotes()
        {
            Assert.AreEqual(new InputFileParameter(@"c:\tmp\a.a").ToCommandLine(), "\"c:\\tmp\\a.a\"");
        }
    }
}
