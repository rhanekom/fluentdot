/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class SubGraphTrackerTests {

        [Test]
        public void AddSubGraph_Keeps_Reference_To_Cluster()
        {
            var cluster1 = new Mock<ICluster>();
            var cluster2 = new Mock<ICluster>();

            cluster1.Setup(x => x.Name).Returns("a");
            cluster2.Setup(x => x.Name).Returns("b");

            var tracker = new SubGraphTracker();
            tracker.AddSubGraph(cluster1.Object);
            tracker.AddSubGraph(cluster2.Object);

            CollectionAssert.Contains(tracker.Clusters, cluster1.Object);
            CollectionAssert.Contains(tracker.Clusters, cluster2.Object);
        }
    }
}