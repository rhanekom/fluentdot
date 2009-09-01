/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Execution;
using FluentDot.Expressions.Execution;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Execution
{
    [TestFixture]
    public class FileOutputExpressionTests {

        [Test]
        public void UsingFormat_Must_Set_Format_On_Parameter()
        {
            var parameter = new OutputFileWithFormatParameter(
                new OutputFileParameter("a"), 
                OutputFormat.ClientSideImageMap
                );

            new FileOutputExpression(parameter).UsingFormat(OutputFormat.GD);

            Assert.AreEqual(parameter.Format, OutputFormat.GD);
            Assert.AreEqual(parameter.OutputFile.FileName, "a");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UsingFormat_Must_Throw_If_Format_Is_Set_To_Null() {
            var parameter = new OutputFileWithFormatParameter(
                new OutputFileParameter("a"),
                OutputFormat.ClientSideImageMap
                );

            new FileOutputExpression(parameter).UsingFormat(null);
        }
    }
}