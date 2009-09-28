/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// Specifies order direction for the graph rank layout.
    /// </summary>
    public class RankDirection : StringEnum, IDotElement
    {
        #region Constants

        /// <summary>
        /// Bottom to top layout.
        /// </summary>
        public static readonly RankDirection BottomToTop = new RankDirection("BT");

        /// <summary>
        /// Top to bottom layout.
        /// </summary>
        public static readonly RankDirection TopToBottom = new RankDirection("TB");

        /// <summary>
        /// Left to right layout.
        /// </summary>
        public static readonly RankDirection LeftToRight = new RankDirection("LR");

        /// <summary>
        /// Right to left layout.
        /// </summary>
        public static readonly RankDirection RightToLeft = new RankDirection("RL");

       

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RankDirection"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public RankDirection(string value) : base(value)
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
        public string ToDot()
        {
            return Value;
        }

        #endregion
    }
}
