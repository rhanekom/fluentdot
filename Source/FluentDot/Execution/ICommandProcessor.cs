/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Diagnostics;

namespace FluentDot.Execution {

    /// <summary>
    /// An executor of processes.
    /// </summary>
    public interface ICommandProcessor {

        /// <summary>
        /// Starts the process.
        /// </summary>
        /// <param name="processInfo">The process info.</param>
        /// <param name="timeOut">How long to wait for the process to end.</param>
        void StartProcess(ProcessStartInfo processInfo, int timeOut);

        /// <summary>
        /// Starts the process.
        /// </summary>
        /// <param name="processInfo">The process info.</param>
        /// <param name="standardInput">The content to write to standard input.</param>
        /// <param name="timeOut">How long to wait for the process to end.</param>
        void StartProcess(ProcessStartInfo processInfo, string standardInput, int timeOut);
    }
}
