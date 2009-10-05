/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that defines an ordering for node edges.
    /// </summary>
    public class OrderingAttribute : AbstractDotAttribute<Ordering>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderingAttribute"/> class.
        /// </summary>
        /// <param name="ordering">The ordering.</param>
        public OrderingAttribute(Ordering ordering) : base("ordering", ordering, true)
        {
            
        }

        #endregion
    }
}