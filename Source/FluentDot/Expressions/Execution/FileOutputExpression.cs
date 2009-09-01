/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Execution;

namespace FluentDot.Expressions.Execution
{
    /// <summary>
    /// A concrete implementaiton of a <see cref="IFileOutputExpression"/>.
    /// </summary>
    public class FileOutputExpression : IFileOutputExpression {
        
        #region Globals

        private readonly OutputFileWithFormatParameter fileParameter;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOutputExpression"/> class.
        /// </summary>
        /// <param name="fileParameter">The file parameter.</param>
        public FileOutputExpression(OutputFileWithFormatParameter fileParameter)
        {
            this.fileParameter = fileParameter;
        }

        #endregion

        #region IFileOutputExpression Members

        /// <summary>
        /// Specifies the format in which the output of dot must be.
        /// </summary>
        /// <param name="format">The output format.</param>
        public void UsingFormat(OutputFormat format) {

            if (format == null)
            {
                throw new ArgumentNullException("format");
            }

            fileParameter.Format = format;
        }

        #endregion
    }
}