/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// A concrete implementation of a <see cref="IElementTracker"/>.
    /// </summary>
    public class ElementTracker : IElementTracker {
        
        #region Globals

        private readonly Dictionary<string, IRecordElement> elements = new Dictionary<string, IRecordElement>();

        #endregion

        #region IElementTracker Members

        /// <summary>
        /// Adds the specified element.
        /// </summary>
        /// <param name="element">The element.</param>
        public void AddElement(IRecordElement element) {
            elements.Add(element.Name, element);
        }

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <value>The elements.</value>
        public IEnumerable<IRecordElement> Elements {
            get { return elements.Values; }
        }

        /// <summary>
        /// Determines whether the tracker contians an element with the specified element name.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns>
        /// 	<c>true</c> if the specified element name was found; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsElement(string elementName) {
            return elements.ContainsKey(elementName);
        }

        #endregion
    }
}