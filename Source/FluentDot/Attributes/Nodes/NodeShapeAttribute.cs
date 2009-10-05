/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Nodes
{
    /// <summary>
    /// A shape attribute that determines the shape of a node.
    /// </summary>
    public class NodeShapeAttribute : AbstractDotAttribute<NodeShape> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeShapeAttribute"/> class.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public NodeShapeAttribute(NodeShape shape) : base("shape", shape, false)
        {

        }

        #endregion
    }
}