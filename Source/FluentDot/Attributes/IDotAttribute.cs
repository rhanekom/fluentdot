/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes
{
    /// <summary>
    /// Represents an attribute in the dot language.
    /// </summary>
    /// <typeparam name="T">The type of value this attribute takes.</typeparam>
    public interface IDotAttribute<T> : IDotAttribute {
        
        /// <summary>
        /// Gets the attribute value.
        /// </summary>
        /// <value>The attribute value.</value>
        new T Value { get; }
    }

    /// <summary>
    /// A dot attribute.
    /// </summary>
    public interface IDotAttribute : IDotElement {

        /// <summary>
        /// Gets the attribute name.
        /// </summary>
        /// <value>The attribute name.</value>
        string Name { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        object Value { get; }
    }
}