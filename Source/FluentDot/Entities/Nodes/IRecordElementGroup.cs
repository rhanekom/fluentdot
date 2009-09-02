/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// A record element group.
    /// </summary>
    public interface IRecordElementGroup : IRecordItem {
        
        /// <summary>
        /// Adds the specified element to the record group.
        /// </summary>
        /// <param name="element">The element to add to the group.</param>
        void AddElement(IRecordItem element);

        /// <summary>
        /// Gets the element tracker.
        /// </summary>
        /// <value>The element tracker.</value>
        IElementTracker ElementTracker { get; }
    }
}