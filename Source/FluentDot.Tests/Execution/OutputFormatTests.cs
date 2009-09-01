/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NUnit.Framework;
using FluentDot.Execution;

namespace FluentDot.Tests.Execution {
    
    [TestFixture]
    public class OutputFormatTests {

        [Test]
        public void ToCommandLine_Should_Ouput_Switch_With_Value()
        {
            Assert.AreEqual(OutputFormat.GIF.ToCommandLine(), "-Tgif");
        }
    }
}
