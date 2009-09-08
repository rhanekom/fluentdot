/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentDot.Common;
using FluentDot.Configuration;

namespace FluentDot.Execution
{
    /// <summary>
    /// A concrete implementation of a <see cref="IDotExecutor"/>.
    /// </summary>
    public class DotExecutor : IDotExecutor {
        
        #region Globals

        private readonly ICommandProcessor commandProcessor;
        private readonly IConfigurationProvider configurationProvider;
        private readonly IFileService fileService;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="DotExecutor"/> class.
        /// </summary>
        public DotExecutor() : this(new CommandProcessor(), GlobalConfiguration.Instance, new FileService())
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DotExecutor"/> class.
        /// </summary>
        /// <param name="commandProcessor">The command processor.</param>
        /// <param name="configurationProvider">The configuration provider.</param>
        /// <param name="fileService">The file service.</param>
        public DotExecutor(ICommandProcessor commandProcessor, IConfigurationProvider configurationProvider, IFileService fileService)
        {
            this.commandProcessor = commandProcessor;
            this.configurationProvider = configurationProvider;
            this.fileService = fileService;
        }

        #endregion

        #region IDotExecutor Members

        /// <summary>
        /// Executes the dot application to generate a graph from the specified dot.
        /// </summary>
        /// <param name="dot">The dot to pass to the dot process.</param>
        /// <param name="outputFiles">The output files to instruct dot to create.</param>
        public void Execute(string dot, IList<OutputFileWithFormatParameter> outputFiles) {

            string dotFile = fileService.CreateTemporaryFile();

            try {
                fileService.WriteAllText(dotFile, dot);

                var startInfo = new ProcessStartInfo
                                    {
                                        Arguments = String.Format("{0} {1}",
                                                                  String.Join(" ",
                                                                              outputFiles.Select(x => x.ToCommandLine())
                                                                                  .ToArray()),
                                                                  new InputFileParameter(dotFile).ToCommandLine()),
                                        FileName = Environment.ExpandEnvironmentVariables(configurationProvider.DotExecutableLocation),
                                        WindowStyle = ProcessWindowStyle.Hidden,
                                        UseShellExecute = false,
                                        CreateNoWindow = true,
                                    };

                commandProcessor.StartProcess(startInfo, configurationProvider.DotProcessTimeout);
            } 
            finally
            {
                fileService.Delete(dotFile);
            }
        }

        #endregion
    }
}