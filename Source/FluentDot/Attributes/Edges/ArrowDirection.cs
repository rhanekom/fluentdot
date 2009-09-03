/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// A strongly typed enum of arrow directions that an edge arrow can take.
    /// </summary>
    public class ArrowDirection : StringEnum, IDotElement {

        #region Constants

        /// <summary>
        /// Sets the edge arrow to point to the tail node of the edge.
        /// </summary>
        public static readonly ArrowDirection Forward = new ArrowDirection("forward");

        /// <summary>
        /// Sets the edge arrow to point to the head node of the edge.
        /// </summary>
        public static readonly ArrowDirection Back = new ArrowDirection("back");

        /// <summary>
        /// Sets the edge arrow to point to both the head node and the tail node of the edge.
        /// </summary>
        public static readonly ArrowDirection Both = new ArrowDirection("both");

        /// <summary>
        /// Configures the edge to have no arrow.
        /// </summary>
        public static readonly ArrowDirection None = new ArrowDirection("none");
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowDirection"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public ArrowDirection(string value)
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