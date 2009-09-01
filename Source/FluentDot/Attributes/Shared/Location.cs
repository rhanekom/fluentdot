/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// Sets the location of elements to be placed at the top or the bottom of the graph.
    /// </summary>
    public class Location : StringEnum {

        #region Constants

        public static readonly Location Top = new Location("t");
        public static readonly Location Bottom = new Location("b");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public Location(string value)
            : base(value)
        {

        }

        #endregion
    }
}