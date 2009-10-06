/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes;

namespace FluentDot.Entities {

    /// <summary>
    /// An entity that can be configured via attributes.
    /// </summary>
    public class AttributeBasedEntity : IAttributeBasedEntity
    {
        #region Globals

        private readonly IAttributeCollection attributes = new AttributeCollection();

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the attributes for the entity.
        /// </summary>
        /// <value>The attributes on the entity.</value>
        public IAttributeCollection Attributes {
            get { return attributes; }
        }

        #endregion
    }
}
