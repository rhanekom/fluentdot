/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Nodes
{
    /// <summary>
    /// An attribute that sets the group on a node.
    /// </summary>
    public class GroupAttribute : AbstractDotAttribute<string> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupAttribute"/> class.
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        public GroupAttribute(string groupName) : base("group", groupName, true)
        {

        }

        #endregion
    }
}