/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Execution;
using NUnit.Framework;

namespace FluentDot.Tests.Execution {

    [TestFixture]
    public class OutputFileWithFormatParameterTests {

        [Test]
        public void Constructor_Should_Set_Properties() {
            const string fileName = "c:\\tmp\\a.gif";
            var outputFile = new OutputFileParameter(fileName);
            OutputFormat format = OutputFormat.GIF;

            var parameter = new OutputFileWithFormatParameter(outputFile, format);

            Assert.AreEqual(parameter.Format, format);
            Assert.AreEqual(parameter.OutputFile, outputFile);
        }

        [Test]
        public void ToCommandLine_Should_Write_Parameters_Correctly() {
            const string fileName = "c:\\tmp\\a.gif";
            var outputFile = new OutputFileParameter(fileName);
            OutputFormat format = OutputFormat.GIF;

            var parameter = new OutputFileWithFormatParameter(outputFile, format);

            string commandLine = parameter.ToCommandLine();
            Assert.AreEqual(commandLine, String.Format("{0} {1}", format.ToCommandLine(), outputFile.ToCommandLine()));
        }
    }
}
