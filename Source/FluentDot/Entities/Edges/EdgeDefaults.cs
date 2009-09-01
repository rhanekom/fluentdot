/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Entities.Edges
{
    /// <summary>
    /// Keeps track of default attributes for edges.
    /// </summary>
    public class EdgeDefaults : EntityDefaultsBase {
        
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeDefaults"/> class.
        /// </summary>
        /// <param name="edge">The edge.</param>
        public EdgeDefaults(IEdge edge)
            : base("edge", edge)
        {

        }

        #endregion
    }
}