/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes;

namespace FluentDot.Entities
{
    public interface IAttributeBasedEntity
    {
        /// <summary>
        /// Gets or sets the attributes for the entity.
        /// </summary>
        /// <value>The attributes on the entity.</value>
        IAttributeCollection Attributes { get; }
    }
}