/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Entities
{
    /// <summary>
    /// A base class for entity defaults.
    /// </summary>
    public class EntityDefaultsBase : IEntityDefaults {

        #region Globals

        private readonly string entityName;
        private readonly IAttributeBasedEntity template;
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityDefaultsBase"/> class.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="template">The template to base the defaults off.</param>
        public EntityDefaultsBase(string entityName, IAttributeBasedEntity template)
        {
            if (String.IsNullOrEmpty(entityName))
            {
                throw new ArgumentException("Invalid entity name specified.", "entityName");
            }

            if (template == null)
            {
                throw new ArgumentNullException("template");
            }

            this.entityName = entityName;
            this.template = template;
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
            return string.Format("{0} {1}", entityName, template.Attributes.ToDot());
        }

        #endregion

        #region IEntityDefaults Members

        /// <summary>
        /// Gets the attribute count.
        /// </summary>
        /// <value>The attribute count.</value>
        public int AttributeCount
        {
            get { return template.Attributes.CurrentAttributes.Count; }
        }

        #endregion
    }
}