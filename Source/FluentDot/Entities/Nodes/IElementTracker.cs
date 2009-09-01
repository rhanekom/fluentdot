/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;

namespace FluentDot.Entities {

    /// <summary>
    /// A tracker for record elements.
    /// </summary>
    public interface IElementTracker {

        /// <summary>
        /// Adds the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        void AddElement(IRecordElement element);

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <value>The elements.</value>
        IEnumerable<IRecordElement> Elements { get; }

        /// <summary>
        /// Determines whether the tracker contians an element with the specified element name.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element name was found; otherwise, <c>false</c>.
        /// </returns>
        bool ContainsElement(string elementName);
    }
}
