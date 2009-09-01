/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FluentDot.Attributes
{
    /// <summary>
    /// A concrete implementation of a <see cref="IAttributeCollection"/>.
    /// </summary>
    public class AttributeCollection : IAttributeCollection {

        #region Globals

        private readonly List<IDotAttribute> attributes = new List<IDotAttribute>();

        #endregion

        #region IAttributeCollection Members

        /// <summary>
        /// Adds the attribute to the collection;
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        public void AddAttribute(IDotAttribute attribute) {
            attributes.Add(attribute);
        }

        /// <summary>
        /// Gets the current attributes.
        /// </summary>
        /// <value>The current attributes.</value>
        public IList<IDotAttribute> CurrentAttributes {
            get { return new ReadOnlyCollection<IDotAttribute>(attributes); }
        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            
            if (attributes.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder("[");

            for (int i = 0; i< attributes.Count; i++)
            {
                sb.Append(attributes[i].ToDot()).Append(", ");
            }

            // Remove our last comma and space
            sb.Remove(sb.Length - 2, 2);
            sb.Append("]");

            return sb.ToString();
        }

        #endregion
    }
}