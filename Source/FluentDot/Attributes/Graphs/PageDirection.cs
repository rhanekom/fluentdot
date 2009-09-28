/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Shared;
using FluentDot.Common;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// Specifies the row or column major orders for traversing a rectangular array, the first direction corresponding to the major order and the second to the minor order.
    /// </summary>
    public class PageDirection : IDotElement {
        
        #region Constants

        /// <summary>
        /// Bottom to top major order, left to right minor order.
        /// </summary>
        public static readonly PageDirection BottomToTopLeftToRight = new PageDirection(VerticalDirection.BottomToTop, HorizontalDirection.LeftToRight);

        /// <summary>
        /// Bottom to top major order, right to left minor order.
        /// </summary>
        public static readonly PageDirection BottomToTopRightToLeft = new PageDirection(VerticalDirection.BottomToTop, HorizontalDirection.RightToLeft);

        /// <summary>
        /// Top to bottom major order, left to right minor order.
        /// </summary>
        public static readonly PageDirection TopToBottomLeftToRight = new PageDirection(VerticalDirection.TopToBottom, HorizontalDirection.LeftToRight);

        /// <summary>
        /// Top to bottom major order, right to left minor order.
        /// </summary>
        public static readonly PageDirection TopToBottomRightToLeft = new PageDirection(VerticalDirection.TopToBottom, HorizontalDirection.RightToLeft);

        /// <summary>
        /// Right to left major order, top to bottom minor order.
        /// </summary>
        public static readonly PageDirection RightToLeftTopToBottom = new PageDirection(HorizontalDirection.RightToLeft, VerticalDirection.TopToBottom);

        /// <summary>
        /// Right to left major order, bottom to top minor order.
        /// </summary>
        public static readonly PageDirection RightToLeftBottomToTop = new PageDirection(HorizontalDirection.RightToLeft, VerticalDirection.BottomToTop);

        /// <summary>
        /// Left to right major order, bottom to top minor order.
        /// </summary>
        public static readonly PageDirection LeftToRightBottomToTop = new PageDirection(HorizontalDirection.LeftToRight, VerticalDirection.BottomToTop);

        /// <summary>
        /// Left to right major order, top to bottom minor order.
        /// </summary>
        public static readonly PageDirection LeftToRightTopToBottom = new PageDirection(HorizontalDirection.LeftToRight, VerticalDirection.TopToBottom);

        #endregion

        #region Globals

        private readonly StringEnum majorOrder;
        private readonly StringEnum minorOrder;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="PageDirection"/> class.
        /// </summary>
        /// <param name="majorOrder">The major order that the rectangular array should be traversed.</param>
        /// <param name="minorOrder">The minor order that the rectangular array should be traversed.</param>
        public PageDirection(VerticalDirection majorOrder, HorizontalDirection minorOrder)
        {
            this.majorOrder = majorOrder;
            this.minorOrder = minorOrder;
            Validate();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageDirection"/> class.
        /// </summary>
        /// <param name="majorOrder">The major order that the rectangular array should be traversed.</param>
        /// <param name="minorOrder">The minor order that the rectangular array should be traversed.</param>
        public PageDirection(HorizontalDirection majorOrder, VerticalDirection minorOrder)
        {
            this.majorOrder = majorOrder;
            this.minorOrder = minorOrder;
            Validate();
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
            return majorOrder.Value + minorOrder.Value;
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
            var other = obj as PageDirection;

            if (other == null)
            {
                return false;
            }

            return Equals(other.majorOrder, majorOrder) && Equals(other.minorOrder, minorOrder);
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
                return ((majorOrder != null ? majorOrder.GetHashCode() : 0)*397) ^ (minorOrder != null ? minorOrder.GetHashCode() : 0);
            }
        }

        #endregion

        #region Private Members

        private void Validate()
        {
            if (majorOrder == null)
            {
                throw new ArgumentNullException("majorOrder");
            }

            if (minorOrder == null)
            {
                throw new ArgumentNullException("minorOrder");
            }
        }

        #endregion
    }
}
