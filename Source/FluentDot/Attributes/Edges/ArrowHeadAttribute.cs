/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// A DOT attribute that specifies the arrow shape of an edge.
    /// </summary>
    public class ArrowHeadAttribute : AbstractDotAttribute<ArrowShapeType>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrowHeadAttribute"/> class.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public ArrowHeadAttribute(ArrowShapeType shape)
            : base("arrowhead", shape, true)
        {

        }
        
        #endregion
    }
}