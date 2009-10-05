/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that specifies the direction the rectangular array should be traversed.
    /// </summary>
    public class PageDirectionAttribute : AbstractDotAttribute<PageDirection>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PageDirectionAttribute"/> class.
        /// </summary>
        /// <param name="pageDirection">The page direction.</param>
        public PageDirectionAttribute(PageDirection pageDirection)
            : base("pagedir", pageDirection, true)
        {

        }

        #endregion
    }
}
