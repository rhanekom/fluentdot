/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An aspect ratio value.
    /// </summary>
    public class AspectValue : IDotElement {

        #region Globals

        private readonly string dotValue;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AspectValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public AspectValue(double value)
        {
            dotValue = value.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AspectValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maximumPassCount">The maximum pass count.</param>
        public AspectValue(double value, int maximumPassCount)
        {
            dotValue = string.Format("{0},{1}", value, maximumPassCount);
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
            return dotValue;
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
            var other = obj as AspectValue;

            if (other == null)
            {
                return false;
            }

            return dotValue == other.dotValue;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode() {
            return (dotValue != null ? dotValue.GetHashCode() : 0);
        }

        #endregion
    }
}
