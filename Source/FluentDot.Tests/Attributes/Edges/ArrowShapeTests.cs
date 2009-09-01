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
    public class ArrowShapeTests {

        [Test]
        public void Constructor_Should_Save_Values()
        {
            var shape = new ArrowShape("testvalue", true, false);
            Assert.IsTrue(shape.LRModifierAllowed); ;
            Assert.IsFalse(shape.OModifierAllowed);
            Assert.AreEqual(shape.Value, "testvalue");
        }

        [Test]
        public void ToDot_Produces_Value_With_No_Modifiers()
        {
            Assert.AreEqual(new ArrowShape("testvalue", true, true).ToDot(), "testvalue");
        }

        [Test]
        public void ToDot_Includes_Modifiers() {
            Assert.AreEqual((new ArrowShape("testvalue", true, true).Modify(ArrowShapeModifier.LeftClip).ToDot()), "ltestvalue");

            Assert.AreEqual((new ArrowShape("testvalue", true, true).Modify(ArrowShapeModifier.RightClip))
                                .ToDot(), "rtestvalue");

            Assert.AreEqual((new ArrowShape("testvalue", true, true).Modify(ArrowShapeModifier.Open))
                                .ToDot(), "otestvalue");

            Assert.AreEqual((new ArrowShape("testvalue", true, true).Modify(ArrowShapeModifier.Open | ArrowShapeModifier.LeftClip))
                                .ToDot(), "lotestvalue");

            Assert.AreEqual((new ArrowShape("testvalue", true, true).Modify(ArrowShapeModifier.Open | ArrowShapeModifier.RightClip))
                                .ToDot(), "rotestvalue");
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Modifiers_L_And_R_Can_Not_Be_Used_Together()
        {
            new ArrowShape("bla", true, true).Modify(ArrowShapeModifier.LeftClip | ArrowShapeModifier.RightClip);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Modifiers_Should_Throw_If_L_Not_Allowed() {
            new ArrowShape("bla", false, true).Modify(ArrowShapeModifier.LeftClip);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Modifiers_Should_Throw_If_R_Not_Allowed() {
            new ArrowShape("bla", false, true).Modify(ArrowShapeModifier.RightClip);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Modifiers_Should_Throw_If_L_And_R_Not_Allowed() {
            new ArrowShape("bla", false, true).Modify(ArrowShapeModifier.LeftClip | ArrowShapeModifier.RightClip);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Modifiers_Should_Throw_If_O_Not_Allowed() {
            new ArrowShape("bla", true, false).Modify(ArrowShapeModifier.Open);
        }
    }
}