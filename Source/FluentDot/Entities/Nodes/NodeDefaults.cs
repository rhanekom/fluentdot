/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// Keeps track of (and formats) default attributes for graph nodes.
    /// </summary>
    public class NodeDefaults : EntityDefaultsBase {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeDefaults"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public NodeDefaults(IGraphNode node)
            : base("node", node)
        {
            
        }

        #endregion
    }
}