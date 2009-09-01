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
    /// An ordering of the appearance of node edges.
    /// </summary>
    public class Ordering : StringEnum, IDotElement
    {
        #region Constants

        public static readonly Ordering In = new Ordering("in");
        public static readonly Ordering Out = new Ordering("out");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Ordering"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public Ordering(string value) : base(value)
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