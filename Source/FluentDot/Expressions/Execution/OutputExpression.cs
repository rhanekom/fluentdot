/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using FluentDot.Configuration;
using FluentDot.Execution;

namespace FluentDot.Expressions.Execution
{
    /// <summary>
    /// A concrete implementation of a <see cref="IOutputExpression"/>.
    /// </summary>
    public class OutputExpression : IOutputExpression {

        #region Globals

        private readonly IConfigurationProvider configurationProvider;
        private readonly List<OutputFileWithFormatParameter> outputParameters = new List<OutputFileWithFormatParameter>();
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputExpression"/> class.
        /// </summary>
        public OutputExpression() : this(GlobalConfiguration.Instance)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputExpression"/> class.
        /// </summary>
        /// <param name="configurationProvider">The configuration provider.</param>
        public OutputExpression(IConfigurationProvider configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        #endregion

        #region IOutputExpression Members

        /// <summary>
        /// Specifies that the dot output should be written to a file.
        /// </summary>
        /// <param name="fileName">Name of the file to write the output of the dot executable to.</param>
        /// <returns>
        /// An expression that can be used to specify file output parameters.
        /// </returns>
        public IFileOutputExpression ToFile(string fileName) {
            var parameter = new OutputFileWithFormatParameter(
                new OutputFileParameter(fileName), 
                configurationProvider.DefaultFileFormat
                );

            outputParameters.Add(parameter);
            return new FileOutputExpression(parameter);
        }

        #endregion

        #region Public

        /// <summary>
        /// Gets the output parameters.
        /// </summary>
        /// <value>The output parameters.</value>
        public IList<OutputFileWithFormatParameter> OutputParameters {
            get { return outputParameters; }
        }

        #endregion
    }
}