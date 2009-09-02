/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Linq;
using FluentDot.Entities.Graphs;
using FluentDot.Entities.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Entities.Nodes
{
    [TestFixture]
    public class NodeTrackerTests {

        [Test]
        public void Add_Should_Add_Node_To_Collection()
        {
            var tracker = new NodeTracker();
            var node = new GraphNode("name");
            tracker.AddNode(node);
            Assert.AreEqual(tracker.Nodes.Count(), 1);
            Assert.AreSame(tracker.Nodes.First(), node);
        }

        [Test]
        public void GetNodeByName_Should_Retrieve_Node_By_Name()
        {
            var tracker = new NodeTracker();
            var node1 = new GraphNode("name1");
            var node2 = new GraphNode("name2");
            
            tracker.AddNode(node1);
            tracker.AddNode(node2);

            Assert.AreEqual(tracker.Nodes.Count(), 2);

            Assert.AreSame(tracker.GetNodeByName("name1"), node1);
            Assert.AreSame(tracker.GetNodeByName("name2"), node2);
        }

        [Test]
        public void GetNodeByName_With_Invalid_Name_Should_Return_Null() {
            var tracker = new NodeTracker();
            var node1 = new GraphNode("name1");
        
            tracker.AddNode(node1);
        
            Assert.AreEqual(tracker.Nodes.Count(), 1);

            Assert.IsNull(tracker.GetNodeByName("name2"));
        }

        [Test]
        public void GetNodeByTag_Should_Retrieve_Node_By_Tag() {
            var tracker = new NodeTracker();
            
            var node1 = new GraphNode("name1") {Tag = 1};
            var node2 = new GraphNode("name2") {Tag = 2};

            tracker.AddNode(node1);
            tracker.AddNode(node2);

            Assert.AreEqual(tracker.Nodes.Count(), 2);

            Assert.AreSame(tracker.GetNodeByTag(1), node1);
            Assert.AreSame(tracker.GetNodeByTag(2), node2);
        }

        [Test]
        public void GetNodeByTag_With_Invalid_Tag_Should_Return_Null() {
            var tracker = new NodeTracker();

            var node1 = new GraphNode("name1") { Tag = 1 };
            tracker.AddNode(node1);
            
            Assert.AreEqual(tracker.Nodes.Count(), 1);

            Assert.IsNull(tracker.GetNodeByTag(2));
        }
    }
}