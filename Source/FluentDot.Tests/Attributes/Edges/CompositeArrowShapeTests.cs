/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Edges;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Edges
{
    [TestFixture]
    public class CompositeArrowShapeTests {

        [Test]
        public void ToDot_Appends_Arrow_Shapes()
        {
            var shape = new CompositeArrowShape(ArrowShape.Box, ArrowShape.Crow.Modify(ArrowShapeModifier.LeftClip));
            Assert.AreEqual(shape.ToDot(), ArrowShape.Box.ToDot() + ArrowShape.Crow.Modify(ArrowShapeModifier.LeftClip).ToDot());
        }
    }
}