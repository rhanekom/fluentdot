/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Nodes;
using FluentDot.Attributes.Shared;
using FluentDot.Entities.Graphs;

namespace FluentDot.Entities {

    /// <summary>
    /// A node that is of type record.
    /// </summary>
    public class RecordNode : GraphNode, IRecordNode {

        #region Globals

        private readonly RecordGroup group;
        private bool attributesAdded = false;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordGroup"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="group">The group of elements to add.</param>
        public RecordNode(string name, RecordGroup group)
            : base(name) {

            if (group == null) {
                throw new ArgumentNullException("group");
            }

            this.group = group;

            ElementTracker = group.ElementTracker;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets a value indicating whether this instance has rounded corners.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has rounded corners; otherwise, <c>false</c>.
        /// </value>
        public bool HasRoundedCorners { get; set; }

        /// <summary>
        /// Gets the record group.
        /// </summary>
        /// <value>The record group.</value>
        public RecordGroup RecordGroup { get { return group; } }

        /// <summary>
        /// Gets or sets the element tracker.
        /// </summary>
        /// <value>The element tracker.</value>
        public IElementTracker ElementTracker { get; private set; }

        #endregion

        #region GraphNode Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public override string ToDot() {

            // Only emit this node as a record if it contains elements.
            if ((group.Elements.Count > 0) && (!attributesAdded)){
                
                // Add the labels, and then surrender control to the base node dot generation.
                Attributes.AddAttribute(new NodeShapeAttribute(new NodeShape(HasRoundedCorners ? "Mrecord" : "record")));
                Attributes.AddAttribute(new LabelAttribute(group.ToDot()));

                attributesAdded = true;
            }

            return base.ToDot();
        }

        #endregion
    }
}
