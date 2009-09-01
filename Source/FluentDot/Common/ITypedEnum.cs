/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Common
{
    /// <summary>
    /// An enum that has an associated type.
    /// </summary>
    public interface ITypedEnum<T> {

        /// <summary>
        /// Gets the value that this instance represents.
        /// </summary>
        /// <value>The value.</value>
        T Value { get; }
    }
}