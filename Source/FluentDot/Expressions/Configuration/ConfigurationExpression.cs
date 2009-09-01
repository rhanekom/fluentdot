/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Configuration;
using FluentDot.Execution;
using FluentDot.Expressions.Shared;

namespace FluentDot.Expressions.Configuration
{
    /// <summary>
    /// A concrete implementation of a <see cref="IConfigurationExpression"/>.
    /// </summary>
    public class ConfigurationExpression : IConfigurationExpression {
        
        #region Globals

        private readonly IConfigurationProvider configurationProvider;

        #endregion

        #region Construction
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationExpression"/> class.
        /// </summary>
        /// <param name="configurationProvider">The configuration provider.</param>
        public ConfigurationExpression(IConfigurationProvider configurationProvider)
        {
            this.configurationProvider = configurationProvider;
        }

        #endregion

        #region IConfigurationExpression Members

        /// <summary>
        /// Sets the full path to the dot executable.
        /// </summary>
        /// <returns>An action expression to specify the value.</returns>
        public IActionExpression<string> DotFilePath
        {
            get {
                return new ActionExpression<string>(x => configurationProvider.DotExecutableLocation = x);
            }
        }

        /// <summary>
        /// Specifies the Dot Process timeout.
        /// </summary>
        /// <returns>An action expression to specify the value.</returns>
        public IActionExpression<int> DotProcessTimeout {
            get {
                return new ActionExpression<int>(x => configurationProvider.DotProcessTimeout = x);
            }
        }

        /// <summary>
        /// Sets the default file format.
        /// </summary>
        /// <returns>An action expression to specify the value.</returns>
        public IActionExpression<OutputFormat> DefaultFileFormat
        {
            get { return new ActionExpression<OutputFormat>(x => configurationProvider.DefaultFileFormat = x); }
        }

        #endregion
    }
}