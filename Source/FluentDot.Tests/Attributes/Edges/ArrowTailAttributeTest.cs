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
    public class ArrowHeadAttributeTests {

        [Test]
        public void ToDot_Produces_Correct_Dot() {
            Assert.AreEqual(
                new ArrowTailAttribute(ArrowShape.Inverted).ToDot(),
                "arrowtail=\"inv\""
                );
        }

        [Test]
        public void ToDot_Produces_Correct_Dot_With_Composite_Shape() {
            Assert.AreEqual(
                new ArrowTailAttribute(new CompositeArrowShape(ArrowShape.Box, ArrowShape.Crow)).ToDot(),
                String.Format("arrowtail=\"{0}{1}\"", ArrowShape.Box, ArrowShape.Crow)
                );
        }
    }
}