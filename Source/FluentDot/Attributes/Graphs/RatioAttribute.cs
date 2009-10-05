/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute that sets the ratio or ratio behaviour of the graph.
    /// </summary>
    public class RatioAttribute : AbstractDotAttribute<RatioType>
    {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RatioAttribute"/> class.
        /// </summary>
        /// <param name="ratio">The ratio.</param>
        public RatioAttribute(RatioType ratio)
            : base("ratio", ratio, true)
        {

        }

        #endregion
    }
}
