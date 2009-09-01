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
    public class OutputFileParameterTests {

        [Test]
        public void Constructor_Should_Set_Properties()
        {
            const string fileName = "c:\\tmp\\a.gif";
            
            var parameter = new OutputFileParameter(fileName);
            
            Assert.AreEqual(parameter.FileName, fileName);
        }

        [Test]
        public void ToCommandLine_Should_Write_Parameters_Correctly()
        {
            const string fileName = "c:\\tmp\\a.gif";

            string commandLine = new OutputFileParameter(fileName).ToCommandLine();
            Assert.AreEqual(commandLine, "\"-oc:\\tmp\\a.gif\"");
        }
    }
}
