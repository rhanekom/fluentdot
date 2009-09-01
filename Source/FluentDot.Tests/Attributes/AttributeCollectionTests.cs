/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Attributes
{
    [TestFixture]
    public class AttributeCollectionTests {
        
        #region Tests

        [Test]
        public void Add_Adds_Attribute_To_Collection()
        {
            var attribute1 = MockRepository.GenerateMock<IDotAttribute>();
            var attribute2 = MockRepository.GenerateMock<OtherDotAttribute>();
            
            var collection = new AttributeCollection();
            
            collection.AddAttribute(attribute1);
            Assert.AreEqual(collection.CurrentAttributes.Count, 1);
            Assert.AreSame(collection.CurrentAttributes[0], attribute1);

            collection.AddAttribute(attribute2);
            Assert.AreEqual(collection.CurrentAttributes.Count, 2);
            Assert.AreSame(collection.CurrentAttributes[0], attribute1);
            Assert.AreSame(collection.CurrentAttributes[1], attribute2);
        }

        [Test]
        public void Add_Does_Not_Replace_Existing_Attributes() {
            var attribute1 = new TestDotAttribute();
            var attribute2 = new TestDotAttribute();
            
            var collection = new AttributeCollection();

            collection.AddAttribute(attribute1);
            Assert.AreEqual(collection.CurrentAttributes.Count, 1);
            Assert.AreSame(collection.CurrentAttributes[0], attribute1);
            
            collection.AddAttribute(attribute2);
            Assert.AreEqual(collection.CurrentAttributes.Count, 1);
            Assert.AreSame(collection.CurrentAttributes[0], attribute1);
        }

        [Test]
        public void ToDot_Generates_Dot_For_All_Attributes()
        {
            var attribute1 = MockRepository.GenerateMock<IDotAttribute>();
            var attribute2 = MockRepository.GenerateMock<OtherDotAttribute>();

            var collection = new AttributeCollection();

            collection.AddAttribute(attribute1);
            collection.AddAttribute(attribute2);


            attribute1.Expect(x => x.ToDot()).Return("label=\"some label\"");
            attribute2.Expect(x => x.ToDot()).Return("fontcolor=darkgreen");

            string dot = collection.ToDot();

            attribute1.VerifyAllExpectations();
            attribute2.VerifyAllExpectations();

            Assert.AreEqual(dot, "[label=\"some label\", fontcolor=darkgreen]");
        }

        [Test]
        public void ToDot_Generates_Dot_Correctly_With_Only_One_Attribute() {
            var attribute = MockRepository.GenerateMock<IDotAttribute>();
            
            var collection = new AttributeCollection();
            collection.AddAttribute(attribute);

            attribute.Expect(x => x.ToDot()).Return("label=\"some label\"");

            string dot = collection.ToDot();

            attribute.VerifyAllExpectations();

            Assert.AreEqual(dot, "[label=\"some label\"]");
        }

        [Test]
        public void ToDot_With_No_Elements_Should_Return_Empty_String() {
            var collection = new AttributeCollection();
            Assert.AreEqual(collection.ToDot(), String.Empty);
        }

        #endregion

        #region Private Members

        public interface OtherDotAttribute : IDotAttribute {
        }

        private class TestDotAttribute : IDotAttribute {

            #region IDotAttribute Members

            public string Name {
                get { throw new NotImplementedException(); }
            }

            public object Value {
                get { throw new NotImplementedException(); }
            }

            #endregion

            #region IDotElement Members

            public string ToDot() {
                throw new NotImplementedException();
            }

            #endregion
        }

        #endregion
    }
}