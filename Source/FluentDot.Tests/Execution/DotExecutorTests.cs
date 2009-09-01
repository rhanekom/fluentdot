/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Diagnostics;
using System.Linq;
using FluentDot.Configuration;
using FluentDot.Execution;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using FluentDot.Common;

namespace FluentDot.Tests.Execution {
    
    [TestFixture]
    public class DotExecutorTests {

        [Test]
        public void Execute_Should_Pass_Dot_To_Process()
        {
            const string dot = "going dotty";
            var outputFileParameters = new[] {
                new OutputFileWithFormatParameter(new OutputFileParameter("c:\\tmp\a.map"), OutputFormat.IMAP),
                new OutputFileWithFormatParameter(new OutputFileParameter("c:\\tmp\a.gif"), OutputFormat.GIF),
            };

            const string dotPath = "c:\\tmp\\a.bat";
            const string temporaryDot = "c:\\tmp\\a.dot";
            const int timeOut = 1000;

            var configurationProvider = MockRepository.GenerateMock<IConfigurationProvider>();
            configurationProvider.Expect(x => x.DotProcessTimeout).Return(timeOut);
            configurationProvider.Expect(x => x.DotExecutableLocation).Return(dotPath);

            var fileService = MockRepository.GenerateMock<IFileService>();
            fileService.Expect(x => x.CreateTemporaryFile()).Return(temporaryDot);
            fileService.Expect(x => x.WriteAllText(temporaryDot, dot));
            fileService.Expect(x => x.Delete(temporaryDot));


            var commandProcessor = MockRepository.GenerateMock<ICommandProcessor>();
            commandProcessor.Expect(x => x.StartProcess(null, timeOut))
                .IgnoreArguments()
                .Constraints(
                    Is.Matching<ProcessStartInfo>(x => 
                        x.WindowStyle == ProcessWindowStyle.Hidden &&
                        x.FileName == dotPath &&
                        x.Arguments == String.Join(" ", outputFileParameters.Select(p => p.ToCommandLine()).ToArray())  + " \"" + temporaryDot + "\""
                    ),
                    Is.Matching<int>(x => 
                        x == timeOut)
                );


            var dotExecutor = new DotExecutor(commandProcessor, configurationProvider, fileService);

            dotExecutor.Execute(dot, outputFileParameters);

            configurationProvider.VerifyAllExpectations();
            fileService.VerifyAllExpectations();
            commandProcessor.VerifyAllExpectations();
        }
    }
}
