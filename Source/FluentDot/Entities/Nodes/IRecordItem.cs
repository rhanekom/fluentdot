/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Entities.Nodes
{
    /// <summary>
    /// A single record item whether that be a group, or a single element.
    /// </summary>
    public interface IRecordItem : IDotElement {

        /// <summary>
        /// Gets or sets a value indicating whether this instance is inverted.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is inverted; otherwise, <c>false</c>.
        /// </value>
        bool IsInverted { get; set; }
    }
}