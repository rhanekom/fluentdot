/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using FluentDot.Common;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// A collection of <see cref="ArrowShape"/>s.
    /// </summary>
    public class CompositeArrowShape : IDotElement {

        #region Globals

        private readonly IList<ArrowShape> arrowShapes;
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CompositeArrowShape"/> class.
        /// </summary>
        /// <param name="arrowShapes">The arrow shapes.</param>
        public CompositeArrowShape(params ArrowShape[] arrowShapes) {
            this.arrowShapes = arrowShapes;
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
            return String.Join(String.Empty, arrowShapes.Select(x => x.ToDot()).ToArray());
        }

        #endregion

        #region Object Members

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">The <paramref name="obj"/> parameter is null.</exception>
        public override bool Equals(object obj)
        {
            var shape = obj as CompositeArrowShape;

            if (shape == null)
            {
                return false;
            }

            if (arrowShapes.Count != shape.arrowShapes.Count)
            {
                return false;
            }

            for (int i = 0; i < arrowShapes.Count; i++)
            {
                if (arrowShapes[i] != shape.arrowShapes[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return (arrowShapes != null ? arrowShapes.GetHashCode() : 0);
        }

        #endregion
    }
}