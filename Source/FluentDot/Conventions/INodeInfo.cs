/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Conventions
{
    /// <summary>
    /// A container class for node information.
    /// </summary>
    public interface INodeInfo
    {
        /// <summary>
        /// Gets the name of the node.
        /// </summary>
        /// <value>The name of the node.</value>
        string Name { get;  }
        
        /// <summary>
        /// Gets the tag attached to the node.
        /// </summary>
        /// <value>The tag attached to the node.</value>
        object Tag { get;} 
    }
}
