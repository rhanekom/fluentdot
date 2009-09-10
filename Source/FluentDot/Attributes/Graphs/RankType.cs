/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// Specifies the rank type in sub graphs.
    /// </summary>
    public class RankType : StringEnum, IDotElement {

        #region Constants
        
        /// <summary>
        /// Causes all the nodes in the subgraph to occur on the same rank.
        /// </summary>
        public static readonly RankType Same = new RankType("same");

        /// <summary>
        /// All the nodes in the subgraph are guaranteed to be on a rank at least 
        /// as small as any other node in the layout.
        /// </summary>
        public static readonly RankType Minimum = new RankType("min");

        /// <summary>
        /// Forces the nodes in the subgraph to be on some rank strictly smaller 
        /// than the rank of any other nodes (except those also speciﬁed by min 
        /// or source subgraphs)
        /// </summary>
        public static readonly RankType Source = new RankType("source");

        /// <summary>
        /// All the nodes in the subgraph are guaranteed to be on a rank at least 
        /// as great as any other node in the layout.
        /// </summary>
        public static readonly RankType Maximum = new RankType("max");

        /// <summary>
        /// Forces the nodes in the subgraph to be on some rank strictly greater 
        /// than the rank of any other nodes (except those also speciﬁed by max 
        /// or sink subgraphs)
        /// </summary>
        public static readonly RankType Sink = new RankType("sink");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RankType"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public RankType(string value)
            : base(value)
        {

        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            return Value;
        }

        #endregion
    }
}
