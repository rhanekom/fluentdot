/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Configuration {

    /// <summary>
    /// Global (static) configuration for FluentDot.
    /// </summary>
    public static class GlobalConfiguration {

        #region Globals

        private static readonly IConfigurationProvider configurationProvider = new ConfigurationProvider();

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the global configuration instance.
        /// </summary>
        /// <value>The instance to configure.</value>
        public static IConfigurationProvider Instance {
            get { return configurationProvider; }
        }

        #endregion
    }
}
