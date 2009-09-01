/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Execution;

namespace FluentDot.Expressions.Execution
{
    /// <summary>
    /// An expression for specifying file output.
    /// </summary>
    public interface IFileOutputExpression {

        /// <summary>
        /// Specifies the format in which the output of dot must be.
        /// </summary>
        /// <param name="format">The output format.</param>
        /// <returns>The graph expression.</returns>
        void UsingFormat(OutputFormat format);
    }
}