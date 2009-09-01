/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Execution {

    /// <summary>
    /// Represents an input file parameter passed to the dot process.
    /// </summary>
    public class InputFileParameter : ICommandParameter {
        
        #region Globals

        private readonly string fileName;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="InputFileParameter"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public InputFileParameter(string fileName)
        {
            this.fileName = fileName;
        }

        #endregion

        #region ICommandParameter Members

        /// <summary>
        /// Creates a textual representation of the command line parameter.
        /// </summary>
        /// <returns>
        /// A textual represetnation of the command line parameter.
        /// </returns>
        public string ToCommandLine() {
            return string.Format("\"{0}\"", fileName);
        }

        #endregion
    }
}
