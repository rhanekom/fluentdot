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
    /// Represents a shape. See http://www.graphviz.org/doc/info/shapes.html for depictions of the different node shapes.
    /// </summary>
    public class NodeShape : StringEnum {

        #region Constants

        /// <summary>
        /// A box shape.
        /// </summary>
        public static NodeShape Box = new NodeShape("box");

        /// <summary>
        /// A Polygon shape.
        /// </summary>
        public static NodeShape Polygon = new NodeShape("polygon");

        /// <summary>
        /// An eelipse shape.
        /// </summary>
        public static NodeShape Ellipse = new NodeShape("ellipse");

        /// <summary>
        /// A circle shape.
        /// </summary>
        public static NodeShape Circle = new NodeShape("circle");

        /// <summary>
        /// A point shape.
        /// </summary>
        public static NodeShape Point = new NodeShape("point");

        /// <summary>
        /// An egg shape.
        /// </summary>
        public static NodeShape Egg = new NodeShape("egg");

        /// <summary>
        /// A triangle shape.
        /// </summary>
        public static NodeShape Triangle = new NodeShape("triangle");

        /// <summary>
        /// No shape, just plain text.
        /// </summary>
        public static NodeShape PlainText = new NodeShape("plaintext");

        /// <summary>
        /// A diamond shape.
        /// </summary>
        public static NodeShape Diamond = new NodeShape("diamond");

        /// <summary>
        /// A trapezium shape.
        /// </summary>
        public static NodeShape Trapezium = new NodeShape("trapezium");

        /// <summary>
        /// A house shape.
        /// </summary>
        public static NodeShape House = new NodeShape("house");

        /// <summary>
        /// A parallelogram shape.
        /// </summary>
        public static NodeShape Parallelogram = new NodeShape("parallelogram");

        /// <summary>
        /// A pentagon (polygon with 5 sides) shape.
        /// </summary>
        public static NodeShape Pentagon = new NodeShape("pentagon");

        /// <summary>
        /// A hexagon (polygon with 6 sides) shape.
        /// </summary>
        public static NodeShape Hexagon = new NodeShape("hexagon");

        /// <summary>
        /// A septagon (polygon with 7 sides) shape.
        /// </summary>
        public static NodeShape Septagon = new NodeShape("septagon");

        /// <summary>
        /// An octagon (polygon with 8 sides) shape.
        /// </summary>
        public static NodeShape Octagon = new NodeShape("octagon");

        /// <summary>
        /// A double circle shape.
        /// </summary>
        public static NodeShape DoubleCircle = new NodeShape("doublecircle");

        /// <summary>
        /// A double octagon shape.
        /// </summary>
        public static NodeShape DoubleOctagon = new NodeShape("doubleoctagon");

        /// <summary>
        /// A triple octagon shape.
        /// </summary>
        public static NodeShape TripleOctagon = new NodeShape("tripleoctagon");

        /// <summary>
        /// An inverted triangle shape.
        /// </summary>
        public static NodeShape InvertedTriangle = new NodeShape("invtriangle");

        /// <summary>
        /// An inverted trapezium shape.
        /// </summary>
        public static NodeShape InvertedTrapezium = new NodeShape("invtrapezium");

        /// <summary>
        /// An inverted house shape.
        /// </summary>
        public static NodeShape InvertedHouse = new NodeShape("invhouse");

        /// <summary>
        /// A modified diamond shape. 
        /// </summary>
        public static NodeShape MDiamond = new NodeShape("Mdiamond");

        /// <summary>
        /// A modified square shape.
        /// </summary>
        public static NodeShape MSquare = new NodeShape("Msquare");

        /// <summary>
        /// A modified circle shape.
        /// </summary>
        public static NodeShape MCircle = new NodeShape("Mcircle");

        /// <summary>
        /// A rectangle shape.
        /// </summary>
        public static NodeShape Rectangle = new NodeShape("rectangle");

        /// <summary>
        /// No shape.
        /// </summary> 
        public static NodeShape None = new NodeShape("none");

        /// <summary>
        /// A note shape.
        /// </summary>
        public static NodeShape Note = new NodeShape("note");

        /// <summary>
        /// A tab shape.
        /// </summary>
        public static NodeShape Tab = new NodeShape("tab");

        /// <summary>
        /// A folder shape.
        /// </summary>
        public static NodeShape Folder = new NodeShape("folder");

        /// <summary>
        /// A 3D box shape.
        /// </summary>
        public static NodeShape Box3D = new NodeShape("box3d");

        /// <summary>
        /// A component shape.
        /// </summary>
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