/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Common
{
    /// <summary>
    /// An element in the Dot language.
    /// </summary>
    public interface IDotElement {

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>A textual Dot representation of this element.</returns>
        string ToDot();
    }
}