﻿/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Edges;
using FluentDot.Attributes.Nodes;
using FluentDot.Attributes.Graphs;

namespace FluentDot.Attributes.Shared
{
    /// <summary>
    /// An attribute that sets the style on a node or edge.
    /// </summary>
    public class StyleAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleAttribute"/> class.
        /// </summary>
        /// <param name="style">The style.</param>
        public StyleAttribute(NodeStyle style)
            : base("style", style, true)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleAttribute"/> class.
        /// </summary>
        /// <param name="style">The style.</param>
        public StyleAttribute(EdgeStyle style) 
            : base("style", style, true)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleAttribute"/> class.
        /// </summary>
        /// <param name="style">The style.</param>
        public StyleAttribute(ClusterStyle style)
            : base("style", style, true) {

        }

        #endregion
    }
}