/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute that outputs a comment on edges, nodes, and graphs/
    /// </summary>
    public class CommentAttribute : AbstractDotAttribute<string>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CommentAttribute"/> class.
        /// </summary>
        /// <param name="comment">The comment.</param>
        public CommentAttribute(string comment) : base("comment", comment, true)
        {
            
        }

        #endregion
    }
}
