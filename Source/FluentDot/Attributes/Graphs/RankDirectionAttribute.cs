/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs
{

    /// <summary>
    /// An attribute that specifies the rank direction of a graph.
    /// </summary>
    public class RankDirectionAttribute : AbstractDotAttribute<RankDirection>
    {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RankDirectionAttribute"/> class.
        /// </summary>
        /// <param name="rankDirection">The rank direction.</param>
        public RankDirectionAttribute(RankDirection rankDirection)
            : base("rankdir", rankDirection, true)
        {

        }

        #endregion
    }
}
