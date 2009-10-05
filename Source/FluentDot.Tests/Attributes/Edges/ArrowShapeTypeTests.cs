/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Edges;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Edges
{
    [TestFixture]
    public class ArrowShapeTypeTests
    {
        [Test]
        public void ToDot_Produces_CompositeArrowShape_Value_If_Specified()
        {
            var shape = new CompositeArrowShape(ArrowShape.Box, ArrowShape.Crow);
            Assert.AreEqual(new ArrowShapeType(shape).ToDot(), shape.ToDot());
        }

        [Test]
        public void ToDot_Produces_ArrowShape_Value_If_Specified()
        {
            var shape = ArrowShape.Box;
            Assert.AreEqual(new ArrowShapeType(shape).ToDot(), shape.ToDot());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Throws_If_ArrowShape_Null()
        {
            new ArrowShapeType((ArrowShape)null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Throws_If_CompositeArrowShape_Null()
        {
            new ArrowShapeType((CompositeArrowShape) null);
        }
    }
}
