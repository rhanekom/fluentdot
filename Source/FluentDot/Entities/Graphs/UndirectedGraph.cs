﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Entities.Graphs
{
    /// <summary>
    /// A concrete implementation of a <see cref="IUndirectedGraph"/>.
    /// </summary>
    public class UndirectedGraph : AbstractGraph , IUndirectedGraph {

        #region AbstractGraph Members

        /// <summary>
        /// Gets or sets the type of graph this instance represents.
        /// </summary>
        /// <value>The type of graph.</value>
        public override GraphType Type
        {
            get { return GraphType.Undirected; }
        }

        /// <summary>
        /// Gets the graph indicator.
        /// </summary>
        /// <value>The graph indicator.</value>
        protected override string GraphIndicator {
            get { return "graph"; }
        }
       
        #endregion
    }
}