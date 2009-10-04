/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that specifies the desired minimuim rank separation in inches. 
    /// </summary>
    public class RankSeperationAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RankSeperationAttribute"/> class.
        /// </summary>
        /// <param name="seperation">The seperation.</param>
        public RankSeperationAttribute(RankSeperation seperation) : base("ranksep", seperation, true)
        {
            
        }

        #endregion
    }
}
