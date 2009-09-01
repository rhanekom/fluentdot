/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Entities {

    /// <summary>
    /// A single element in a record group.
    /// </summary>
    public class RecordElement : IRecordElement {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordElement"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public RecordElement(string name) {
            if (string.IsNullOrEmpty(name)) {
                throw new ArgumentException("Invalid name specified.", "name");
            }

            Name = name;
        }

        #endregion

        #region IRecordElement Members

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name {
            get;
            private set;
        }

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
        /// Gets or sets the label.
        /// </summary>
        /// <value>The label.</value>
        public string Label { get; set; }

        #endregion

        #region IDotElement Members

        public string ToDot() {
            
            string label = String.IsNullOrEmpty(Label) ? Name : Label;
            
            // Escape all invalid characters
            label = label.Replace("{", @"\{");
            label = label.Replace("}", @"\}");
            label = label.Replace("|", @"\|");
            label = label.Replace("<", @"\<");
            label = label.Replace(">", @"\>");
            label = label.Replace(" ", @"\ ");

            return IsInverted
                ? String.Format(@"{{<{0}> {1}}}", Name, label)
                : String.Format("<{0}> {1}", Name, label);
        }

        #endregion
    }
}
