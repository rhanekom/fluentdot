/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Configuration;
using FluentDot.Execution;
using FluentDot.Expressions.Configuration;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Configuration
{
    [TestFixture]
    public class ConfigurationExpressionTests {

        [Test]
        public void DotFilePath_Sets_FilePath_On_Configuration()
        {
            const string expected = "c:\\tmp\\a.tt";
            
            var configurationProvider = new Mock<IConfigurationProvider>();

            var expression = new ConfigurationExpression(configurationProvider.Object);
            expression.DotFilePath.Is(expected);

            configurationProvider.VerifySet(x => x.DotExecutableLocation = expected);
        }

        [Test]
        public void DotProcessTimeout_Sets_DotProcessTimeout_On_Configuration() {
            const int expected = 2312;

            var configurationProvider = new Mock<IConfigurationProvider>();

            var expression = new ConfigurationExpression(configurationProvider.Object);
            expression.DotProcessTimeout.Is(expected);
            
            configurationProvider.VerifySet(x => x.DotProcessTimeout = expected);
        }

        [Test]
        public void DefaultFileFormat_Sets_DefaultFileFormat_On_Configuration()
        {
            var configurationProvider = new Mock<IConfigurationProvider>();

                var expression = new ConfigurationExpression(configurationProvider.Object);
            expression.DefaultFileFormat.Is(OutputFormat.GD);

            configurationProvider.VerifySet(x => x.DefaultFileFormat = OutputFormat.GD);
        }
    }
}