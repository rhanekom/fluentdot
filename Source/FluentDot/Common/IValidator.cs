/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Common {

    /// <summary>
    /// A validator of objects.
    /// </summary>
    /// <typeparam name="T">The type of object to validate.</typeparam>
    public interface IValidator<T> {

        /// <summary>
        /// Determines whether the specified instance is valid.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="message">The error message if the instance is invalid.</param>
        /// <returns>
        /// 	<c>true</c> if the specified instance is valid; otherwise, <c>false</c>.
        /// </returns>
        bool IsValid(T instance, out string message);
    }
}
