/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Entities {

    /// <summary>
    /// Default attributes for an entity.
    /// </summary>
    public interface IEntityDefaults : IDotElement {

        /// <summary>
        /// Gets the attribute count.
        /// </summary>
        /// <value>The attribute count.</value>
        int AttributeCount { get; }
    }
}
