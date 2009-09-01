/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Execution {

    /// <summary>
    /// A parameter for specifying the output file and format of the output file.
    /// </summary>
    public class OutputFileWithFormatParameter : ICommandParameter {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFileParameter"/> class.
        /// </summary>
        /// <param name="outputFile">The output file.</param>
        /// <param name="outputFormat">The output format.</param>
        public OutputFileWithFormatParameter(OutputFileParameter outputFile, OutputFormat outputFormat) {
            OutputFile = outputFile;
            Format = outputFormat;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the output file.
        /// </summary>
        /// <value>The output file.</value>
        public OutputFileParameter OutputFile { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>The format.</value>
        public OutputFormat Format { get; set; }

        #endregion

        #region ICommandParameter Members

        /// <summary>
        /// Creates a textual representation of the command line parameter.
        /// </summary>
        /// <returns>
        /// A textual represetnation of the command line parameter.
        /// </returns>
        public string ToCommandLine() {
            return string.Format("{0} {1}", Format.ToCommandLine(), OutputFile.ToCommandLine());
        }

        #endregion
    }
}
