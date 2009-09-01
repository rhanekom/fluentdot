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
    /// A storngly typed instance of a DOT arrow shape.
    /// </summary>
    public interface IArrowShape : IDotElement, ICloneable
    {
        /// <summary>
        /// Gets a value indicating whether the L or R modifier is allowed on this shape..
        /// </summary>
        /// <value><c>true</c> if [LR modifier allowed]; otherwise, <c>false</c>.</value>
        bool LRModifierAllowed { get; }

        /// <summary>
        /// Gets a value indicating whether the O modifier is allowed on this shape.
        /// </summary>
        /// <value><c>true</c> if [O modifier allowed]; otherwise, <c>false</c>.</value>
        bool OModifierAllowed { get; }

        /// <summary>
        /// Gets or sets the modifiers on the arrow shape.
        /// </summary>
        /// <value>The modifiers on the arrow shape.</value>
        ArrowShapeModifier Modifiers { get; }

        /// <summary>
        /// Modifies the specified modifications.
        /// </summary>
        /// <param name="modifications">The modifications.</param>
        /// <returns></returns>
        ArrowShape Modify(ArrowShapeModifier modifications);
    }
}