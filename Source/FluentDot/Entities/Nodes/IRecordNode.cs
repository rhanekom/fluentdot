/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;

namespace FluentDot.Entities
{
    /// <summary>
    /// A record node.
    /// </summary>
    public interface IRecordNode : IGraphNode
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance has rounded corners.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has rounded corners; otherwise, <c>false</c>.
        /// </value>
        bool HasRoundedCorners { get; set; }

        /// <summary>
        /// Gets the record group.
        /// </summary>
        /// <value>The record group.</value>
        RecordGroup RecordGroup { get; }

        /// <summary>
        /// Gets or sets the element tracker.
        /// </summary>
        /// <value>The element tracker.</value>
        IElementTracker ElementTracker { get; }
    }
}