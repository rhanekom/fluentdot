/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute that specifies the rank of a subgraph.
    /// </summary>
    public class RankAttribute : AbstractDotAttribute<RankType> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RankAttribute"/> class.
        /// </summary>
        /// <param name="type">The type of rank to apply to the graph.</param>
        public RankAttribute(RankType type)
            : base("rank", type, true)
        {

        }

        #endregion
    }
}
