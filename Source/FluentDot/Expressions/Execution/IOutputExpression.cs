/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Expressions.Execution
{
    /// <summary>
    /// An expression that adds an output file in a specified format.
    /// </summary>
    public interface IOutputExpression {

        /// <summary>
        /// Specifies that the dot output should be written to a file.
        /// </summary>
        /// <param name="fileName">Name of the file to write the output of the dot executable to.</param>
        /// <returns>An expression that can be used to specify file output parameters.</returns>
        IFileOutputExpression ToFile(string fileName);
    }
}