/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Configuration;
using FluentDot.Execution;
using FluentDot.Expressions.Configuration;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Expressions.Configuration
{
    [TestFixture]
    public class ConfigurationExpressionTests {

        [Test]
        public void DotFilePath_Sets_FilePath_On_Configuration()
        {
            const string expected = "c:\\tmp\\a.tt";
            
            var configurationProvider = MockRepository.GenerateMock<IConfigurationProvider>();
            configurationProvider.Expect(x => x.DotExecutableLocation = expected);

            var expression = new ConfigurationExpression(configurationProvider);
            expression.DotFilePath.Is(expected);

            configurationProvider.VerifyAllExpectations();
        }

        [Test]
        public void DotProcessTimeout_Sets_DotProcessTimeout_On_Configuration() {
            const int expected = 2312;

            var configurationProvider = MockRepository.GenerateMock<IConfigurationProvider>();
            configurationProvider.Expect(x => x.DotProcessTimeout = expected);

            var expression = new ConfigurationExpression(configurationProvider);
            expression.DotProcessTimeout.Is(expected);

            configurationProvider.VerifyAllExpectations();
        }

        [Test]
        public void DefaultFileFormat_Sets_DefaultFileFormat_On_Configuration()
        {
            var configurationProvider = MockRepository.GenerateMock<IConfigurationProvider>();
            configurationProvider.Expect(x => x.DefaultFileFormat = OutputFormat.GD);

            var expression = new ConfigurationExpression(configurationProvider);
            expression.DefaultFileFormat.Is(OutputFormat.GD);

            configurationProvider.VerifyAllExpectations();
        }
    }
}