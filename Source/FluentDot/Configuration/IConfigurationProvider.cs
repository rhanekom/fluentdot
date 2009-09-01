/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Execution;

namespace FluentDot.Configuration {

    /// <summary>
    /// FluentDot configuration values.
    /// </summary>
    public interface IConfigurationProvider {

        /// <summary>
        /// Gets or sets the timeout for the dot process.
        /// </summary>
        /// <value>The dot process timeout.</value>
        int DotProcessTimeout { get; set; }

        /// <summary>
        /// Gets or sets the dot executable location.
        /// </summary>
        /// <value>The dot executable location.</value>
        string DotExecutableLocation { get; set; }

        /// <summary>
        /// Gets or sets the default file format.
        /// </summary>
        /// <value>The default file format.</value>
        OutputFormat DefaultFileFormat { get; set; }
    }
}
