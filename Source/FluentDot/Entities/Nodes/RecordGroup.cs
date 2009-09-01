/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentDot.Entities {

    /// <summary>
    /// A group of entries in a record node.
    /// </summary>
    public class RecordGroup : IRecordElementGroup {

        #region Globals

        private readonly List<IRecordItem> elements = new List<IRecordItem>();
        private readonly IElementTracker elementTracker;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordGroup"/> class.
        /// </summary>
        public RecordGroup() : this(new ElementTracker()) {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordGroup"/> class.
        /// </summary>
        /// <param name="elementTracker">The element tracker.</param>
        public RecordGroup(IElementTracker elementTracker)
        {
            this.elementTracker = elementTracker;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordGroup"/> class.
        /// </summary>
        /// <param name="elements">The elements to include in the group.</param>
        public RecordGroup(params IRecordItem[] elements) {

            elementTracker = new ElementTracker();

            if ((elements == null) || (elements.Length == 0)) {
                throw new ArgumentException("At least one record element must be provided.");
            }

            this.elements.AddRange(elements);
        }

        #endregion

        #region IRecordElementGroup Members

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inverted.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is inverted; otherwise, <c>false</c>.
        /// </value>
        public bool IsInverted {
            get;
            set;
        }

        /// <summary>
        /// Adds the specified element to the record group.
        /// </summary>
        /// <param name="element">The element to add to the group.</param>
        public void AddElement(IRecordItem element) {
            elements.Add(element);

            if (element is IRecordElement)
            {
                elementTracker.AddElement(element as IRecordElement);
            }
        }

        /// <summary>
        /// Gets the element tracker.
        /// </summary>
        /// <value>The element tracker.</value>
        public IElementTracker ElementTracker
        {
            get { return elementTracker; }
        }

        /// <summary>
        /// Gets the elements contained by this group.
        /// </summary>
        /// <value>The elements contained by this group.</value>
        public IList<IRecordItem> Elements {
            get {
                return elements;
            }
        }

        #endregion

        #region GraphNode Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            string[] itemsDot = elements.Select(x => x.ToDot()).ToArray();
            string dot = String.Join("|", itemsDot);
            return IsInverted ? String.Format("{{{0}}}", dot) : dot;
        }

        #endregion
    }
}
