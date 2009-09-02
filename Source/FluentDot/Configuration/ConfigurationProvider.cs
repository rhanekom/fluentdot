/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Execution;

namespace FluentDot.Configuration
{
    /// <summary>
    /// A concrete implementation of a <see cref="IConfigurationProvider"/>.
    /// </summary>
    public class ConfigurationProvider : IConfigurationProvider {
        
        #region Globals

        private int dotProcessTimeout = 30000;
        private string dotExecutableLocation = @"C:\Program Files\Graphviz 2.21\bin\dot.exe";
        private OutputFormat defaultFileFormat = OutputFormat.GIF;

        #endregion

        #region IConfigurationProvider Members

        /// <summary>
        /// Gets or sets the timeout for the dot process.
        /// </summary>
        /// <value>The dot process timeout.</value>
        public int DotProcessTimeout {
            get { 
                return dotProcessTimeout; 
            }
            set {

                if (value <= 0)
                {
                    throw new ArgumentException("Invalid dot process timeout specified.", "value");
                }

                dotProcessTimeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the dot executable location.
        /// </summary>
        /// <value>The dot executable location.</value>
        public string DotExecutableLocation
        {
            get { return dotExecutableLocation; }
            set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid dot executable location specified.", "value");
                }

                dotExecutableLocation = value; 
            }
        }

        /// <summary>
        /// Gets or sets the default file format.
        /// </summary>
        /// <value>The default file format.</value>
        public OutputFormat DefaultFileFormat
        {
            get { return defaultFileFormat; }
            set {
                if (value == null)
                {
                    throw new ArgumentException("Invalid default file format specified.", "value");
                }

                defaultFileFormat = value;
            }
        }

        #endregion
    }
}