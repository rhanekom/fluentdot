/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using FluentDot.Common;

namespace FluentDot.Attributes
{
    /// <summary>
    /// A collection of DOT attributes.
    /// </summary>
    public interface IAttributeCollection : IDotElement {

        /// <summary>
        /// Adds the attribute to the collection;
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        void AddAttribute(IDotAttribute attribute);

        /// <summary>
        /// Gets the current attributes.
        /// </summary>
        /// <value>The current attributes.</value>
        IList<IDotAttribute> CurrentAttributes { get; }
    }
}