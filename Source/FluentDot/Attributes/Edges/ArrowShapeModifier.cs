/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// Modifiers that can be applied to arrow shapes.
    /// </summary>
    [Flags]
    public enum ArrowShapeModifier {

        /// <summary>
        /// No modifiers.
        /// </summary>
        None = 0,

        /// <summary>
        /// Clips the shape, leaving only the part to the left of the edge.  Can not be used with RightClip.
        /// </summary>
        LeftClip = 1,

        /// <summary>
        /// Clips the shape, leaving only the part to the right of the edge. Can not be used with LeftClip.
        /// </summary>
        RightClip = 2,

        /// <summary>
        /// Use the open (non-filled) version of the shape.
        /// </summary>
        Open = 4
    }
}