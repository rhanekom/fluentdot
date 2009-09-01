/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;

namespace FluentDot.Execution {

    /// <summary>
    /// A simple command processor that gives stronyly typed access to the dot.exe command line variables.
    /// </summary>
    public interface IDotExecutor {

        /// <summary>
        /// Executes the dot application to generate a graph from the specified dot.
        /// </summary>
        /// <param name="dot">The dot to pass to the dot process.</param>
        /// <param name="outputFiles">The output files to instruct dot to create.</param>
        void Execute(string dot, IList<OutputFileWithFormatParameter> outputFiles);
    }
}
