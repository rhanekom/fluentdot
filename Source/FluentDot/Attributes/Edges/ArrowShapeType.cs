/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Common;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// A container class for defining the shape of an edge arrow.
    /// </summary>
    public class ArrowShapeType : IDotElement
    {
        #region Globals

        private readonly ArrowShape arrowShape;
        private readonly CompositeArrowShape compositeArrowShape;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowShapeType"/> class.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public ArrowShapeType(ArrowShape shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException("shape");
            }

            arrowShape = shape;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowShapeType"/> class.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public ArrowShapeType(CompositeArrowShape shape)
        {
            if (shape == null)
            {
                throw new ArgumentNullException("shape");
            }

            compositeArrowShape = shape;
        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot()
        {
            if (arrowShape != null)
            {
                return arrowShape.ToDot();
            }

            return compositeArrowShape.ToDot();
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
            var other = obj as ArrowShapeType;

            if (other == null)
            {
                return false;
            }

            return Equals(other.arrowShape,arrowShape) && Equals(other.compositeArrowShape,compositeArrowShape);
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((arrowShape != null ? arrowShape.GetHashCode() : 0)*397) ^ (compositeArrowShape != null ? compositeArrowShape.GetHashCode() : 0);
            }
        }

        #endregion
    }
}
