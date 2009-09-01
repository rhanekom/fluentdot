/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Nodes
{
    /// <summary>
    /// Represents a shape.
    /// </summary>
    public class NodeShape : StringEnum {

        #region Constants

        public static NodeShape Box = new NodeShape("box");
        public static NodeShape Polygon = new NodeShape("polygon");
        public static NodeShape Ellipse = new NodeShape("ellipse");
        public static NodeShape Circle = new NodeShape("circle");
        public static NodeShape Point = new NodeShape("point");
        public static NodeShape Egg = new NodeShape("egg");
        public static NodeShape Triangle = new NodeShape("triangle"); 
        public static NodeShape PlainText = new NodeShape("plaintext");
        public static NodeShape Diamond = new NodeShape("diamond");
        public static NodeShape Trapezium = new NodeShape("trapezium");
        public static NodeShape House = new NodeShape("house");
        public static NodeShape Parallelogram = new NodeShape("parallelogram");
        public static NodeShape Pentagon = new NodeShape("pentagon");
        public static NodeShape Hexagon = new NodeShape("hexagon");
        public static NodeShape Septagon = new NodeShape("septagon");
        public static NodeShape Octagon = new NodeShape("octagon");
        public static NodeShape DoubleCircle = new NodeShape("doublecircle");
        public static NodeShape DoubleOctagon = new NodeShape("doubleoctagon");
        public static NodeShape TripleOctagon = new NodeShape("tripleoctagon");
        public static NodeShape InvertedTriangle = new NodeShape("invtriangle");
        public static NodeShape InvertedTrapezium = new NodeShape("invtrapezium");
        public static NodeShape InvertedHouse = new NodeShape("invhouse");
        public static NodeShape MDiamond = new NodeShape("Mdiamond");
        public static NodeShape MSquare = new NodeShape("Msquare");
        public static NodeShape MCircle = new NodeShape("Mcircle");
        public static NodeShape Rectangle = new NodeShape("rectangle");
        public static NodeShape None = new NodeShape("none");
        public static NodeShape Note = new NodeShape("note");
        public static NodeShape Tab = new NodeShape("tab");
        public static NodeShape Folder = new NodeShape("folder");
        public static NodeShape Box3D = new NodeShape("box3d");
        public static NodeShape Component = new NodeShape("component");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeShape"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public NodeShape(string value)
            : base(value)
        {

        }

        #endregion
    }
}