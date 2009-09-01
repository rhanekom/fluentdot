/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Execution;
using FluentDot.Expressions.Shared;

namespace FluentDot.Expressions.Configuration
{
    /// <summary>
    /// An expression to configure the FluentDot environment.
    /// </summary>
    public interface IConfigurationExpression {

        /// <summary>
        /// Sets the full path to the dot executable.
        /// </summary>
        /// <returns>An action expression to specify the value.</returns>
        IActionExpression<string> DotFilePath {get;}

        /// <summary>
        /// Specifies the Dot Process timeout.
        /// </summary>
        /// <returns>An action expression to specify the value.</returns>
        IActionExpression<int> DotProcessTimeout { get; }

        /// <summary>
        /// Sets the default file format.
        /// </summary>
        /// <returns>An action expression to specify the value.</returns>
        IActionExpression<OutputFormat> DefaultFileFormat { get; }
    }
}