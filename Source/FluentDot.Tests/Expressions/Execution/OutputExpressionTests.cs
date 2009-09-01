/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using FluentDot.Configuration;
using FluentDot.Execution;
using FluentDot.Expressions.Execution;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Execution
{
    [TestFixture]
    public class OutputExpressionTests {

        #region Globals

        private const string fileName1 = "a:\\tmp1.bat";
        private const string fileName2 = "a:\\tmp2.bat";

        #endregion

        #region Tests

        [Test]
        public void ToFile_Should_Save_File_With_Format_Specified() {
            
            var expression = new OutputExpression();
            expression.ToFile(fileName1).UsingFormat(OutputFormat.GIF);

            Assert.AreEqual(expression.OutputParameters.Count, 1);

            var outputParameter = expression.OutputParameters[0];

            Assert.AreEqual(outputParameter.Format, OutputFormat.GIF);
            Assert.AreEqual(outputParameter.OutputFile.FileName, fileName1);
        }

        [Test]
        public void ToFile_Should_Save_File_With_Default_Format_If_Not_Specified()
        {
            var configurationProvider = MockRepository.GenerateMock<IConfigurationProvider>();
            configurationProvider.Expect(x => x.DefaultFileFormat).Return(OutputFormat.Canon);

            var expression = new OutputExpression(configurationProvider);
            expression.ToFile(fileName1);

            configurationProvider.VerifyAllExpectations();

            Assert.AreEqual(expression.OutputParameters.Count, 1);

            var outputParameter = expression.OutputParameters[0];

            Assert.AreEqual(outputParameter.Format, OutputFormat.Canon);
            Assert.AreEqual(outputParameter.OutputFile.FileName, fileName1);
        }

        [Test]
        public void ToFile_Preserves_Multiple_Files() {
            var expression = new OutputExpression();
            expression.ToFile(fileName1).UsingFormat(OutputFormat.GIF);
            expression.ToFile(fileName2).UsingFormat(OutputFormat.ClientSideImageMap);

            Assert.AreEqual(expression.OutputParameters.Count, 2);

            var outputParameter = expression.OutputParameters[0];

            Assert.AreEqual(outputParameter.Format, OutputFormat.GIF);
            Assert.AreEqual(outputParameter.OutputFile.FileName, fileName1);

            outputParameter = expression.OutputParameters[1];

            Assert.AreEqual(outputParameter.Format, OutputFormat.ClientSideImageMap);
            Assert.AreEqual(outputParameter.OutputFile.FileName, fileName2);
        }

        #endregion
    }
}