/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Diagnostics;

namespace FluentDot.Execution
{
    /// <summary>
    /// A concrete implementation of a <see cref="ICommandProcessor"/>.
    /// </summary>
    public class CommandProcessor : ICommandProcessor
    {
        #region ICommandProcessor Members

        /// <summary>
        /// Starts the process.
        /// </summary>
        /// <param name="processInfo">The process info.</param>
        /// <param name="timeOut">How long to wait for the process to end.</param>
        public void StartProcess(ProcessStartInfo processInfo, int timeOut) {
            StartProcess(processInfo, null, timeOut);
        }

        /// <summary>
        /// Starts the process.
        /// </summary>
        /// <param name="processInfo">The process info.</param>
        /// <param name="standardInput">The content to write to standard input.</param>
        /// <param name="timeOut">How long to wait for the process to end.</param>
        public void StartProcess(ProcessStartInfo processInfo, string standardInput, int timeOut)
        {
            if (!String.IsNullOrEmpty(standardInput))
            {
                processInfo.RedirectStandardInput = true;
            }

            using (Process process = Process.Start(processInfo))
            {
                if (process != null)
                {

                    if (!String.IsNullOrEmpty(standardInput))
                    {
                        process.StandardInput.Write(standardInput);
                        process.StandardInput.Close();
                    }

                    process.WaitForExit(timeOut);

                    if (!process.HasExited)
                    {
                        process.Kill();
                        throw new ExecutionException("External process has timed out.");
                    }

                    if (process.ExitCode != 0)
                    {
                        throw new ExecutionException("Process returned non-zero - exit code : " + process.ExitCode);
                    }
                }
            }
        }

        #endregion
    }
}