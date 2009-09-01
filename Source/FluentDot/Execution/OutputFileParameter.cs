/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Execution {

    /// <summary>
    /// A parameter for an output file.
    /// </summary>
    public class OutputFileParameter : ICommandParameter {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFileParameter"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public OutputFileParameter(string fileName)
        {
            FileName = fileName;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; private set; }
        
        #endregion

        #region ICommandParameter Members

        /// <summary>
        /// Creates a textual representation of the command line parameter.
        /// </summary>
        /// <returns>
        /// A textual represetnation of the command line parameter.
        /// </returns>
        public string ToCommandLine() {
            return string.Format("\"-o{0}\"", FileName);
        }

        #endregion
    }
}
