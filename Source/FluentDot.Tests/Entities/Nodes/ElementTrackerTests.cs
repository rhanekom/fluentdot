/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Linq;
using FluentDot.Entities;
using NUnit.Framework;

namespace FluentDot.Tests.Entities.Nodes
{
    [TestFixture]
    public class ElementTrackerTests {

        [Test]
        public void Add_Adds_Item_To_Tracker()
        {
            var element = new RecordElement("a");
            var tracker = new ElementTracker();

            Assert.IsFalse(tracker.ContainsElement("a"));
            tracker.AddElement(element);
            Assert.IsTrue(tracker.ContainsElement("a"));

            Assert.AreEqual(tracker.Elements.Count(), 1);
            Assert.AreSame(tracker.Elements.First(), element);
        }
    }
}