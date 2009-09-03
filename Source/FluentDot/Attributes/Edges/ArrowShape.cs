/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Text;
using FluentDot.Common;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// A strongly typed enumeration of the basic dot arrow shapes.
    /// </summary>
    public class ArrowShape : StringEnum, IArrowShape
    {
        #region Constants

        public static ArrowShape Box = new ArrowShape("box", true, true);
        public static ArrowShape Crow = new ArrowShape("crow", true, false);
        public static ArrowShape Diamond = new ArrowShape("diamond", true, true);
        public static ArrowShape Dot = new ArrowShape("dot", false, true);
        public static ArrowShape Inverted = new ArrowShape("inv", true, true);
        public static ArrowShape None = new ArrowShape("none", false, false);
        public static ArrowShape Normal = new ArrowShape("normal", true, true);
        public static ArrowShape Tee = new ArrowShape("tee", true, false);
        public static ArrowShape Vee = new ArrowShape("vee", true, false);

        #endregion

        #region Globals

        private readonly bool allowLRModifier;
        private readonly bool allowOModifier;
        private ArrowShapeModifier modifiers = ArrowShapeModifier.None;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowShape"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        /// <param name="allowLRModifier">if set to <c>true</c> [allow LR modifier].</param>
        /// <param name="allowOModifier">if set to <c>true</c> [allow O modifier].</param>
        public ArrowShape(string value, bool allowLRModifier, bool allowOModifier)
            : base(value)
        {
            this.allowLRModifier = allowLRModifier;
            this.allowOModifier = allowOModifier;
        }

        #endregion

        #region Public members

        /// <summary>
        /// Gets a value indicating whether the L or R modifier is allowed on this shape..
        /// </summary>
        /// <value><c>true</c> if [LR modifier allowed]; otherwise, <c>false</c>.</value>
        public bool LRModifierAllowed {
            get { return allowLRModifier; }
        }

        /// <summary>
        /// Gets a value indicating whether the O modifier is allowed on this shape.
        /// </summary>
        /// <value><c>true</c> if [O modifier allowed]; otherwise, <c>false</c>.</value>
        public bool OModifierAllowed {
            get { return allowOModifier; }
        }

        /// <summary>
        /// Gets or sets the modifiers on the arrow shape.
        /// </summary>
        /// <value>The modifiers on the arrow shape.</value>
        public ArrowShapeModifier Modifiers {
            get {
                return modifiers;
            }
        }

        /// <summary>
        /// Modifies the specified modifications.
        /// </summary>
        /// <param name="modifications">The modifications.</param>
        /// <returns></returns>
        public ArrowShape Modify(ArrowShapeModifier modifications)
        {
            ValidateModifiers(modifications);
            var shape = (ArrowShape) Clone();
            shape.modifiers = modifications;
            return shape;
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone() {
            return new ArrowShape(Value, allowLRModifier, allowOModifier) {modifiers = Modifiers};
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
            var sb = new StringBuilder();

            if ((Modifiers & ArrowShapeModifier.LeftClip) == ArrowShapeModifier.LeftClip)
            {
                sb.Append('l');
            } 
            else if ((Modifiers & ArrowShapeModifier.RightClip) == ArrowShapeModifier.RightClip)
            {
                sb.Append('r');
            }

            if ((Modifiers & ArrowShapeModifier.Open) == ArrowShapeModifier.Open) {
                sb.Append('o');
            }

            sb.Append(Value);

            return sb.ToString();
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
            var shape = obj as ArrowShape;

            if (shape == null)
            {
                return false;
            }

            return shape.Value == Value && shape.Modifiers == Modifiers;
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
                int result = base.GetHashCode();
                result = (result*397) ^ allowLRModifier.GetHashCode();
                result = (result*397) ^ allowOModifier.GetHashCode();
                result = (result*397) ^ modifiers.GetHashCode();
                return result;
            }
        }

        #endregion

        #region Private Members

        private void ValidateModifiers(ArrowShapeModifier value) {
            bool hasLeftClipModifier = ((value & ArrowShapeModifier.LeftClip) == ArrowShapeModifier.LeftClip);
            bool hasRightClipModifier = ((value & ArrowShapeModifier.RightClip) == ArrowShapeModifier.RightClip);

            if ((!allowLRModifier) && (hasLeftClipModifier || hasRightClipModifier)) {
                throw new ArgumentException("The left clip or right clip modifier is not valid for the arrow shape type " + Value + ".");
            }

            if (hasLeftClipModifier && hasRightClipModifier) {
                throw new ArgumentException("Only the left or right of the arrow shape can be clipped - the combination of the two is invalid.");
            }

            bool hasOModifier = ((value & ArrowShapeModifier.Open) == ArrowShapeModifier.Open);

            if (!allowOModifier && hasOModifier) {
                throw new ArgumentException("The open modifier is not valid for the arrow shape type " + Value + ".");
            }
        }

        #endregion
    }
}