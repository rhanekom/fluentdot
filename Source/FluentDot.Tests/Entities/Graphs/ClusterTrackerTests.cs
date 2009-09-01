/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities.Graphs;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Entities.Graphs
{
    [TestFixture]
    public class ClusterTrackerTests {

        [Test]
        public void Add_Cluster_Keeps_Reference_To_Cluster()
        {
            var cluster1 = MockRepository.GenerateMock<ICluster>();
            var cluster2 = MockRepository.GenerateMock<ICluster>();

            cluster1.Expect(x => x.Name).Return("a");
            cluster2.Expect(x => x.Name).Return("b");

            var tracker = new ClusterTracker();
            tracker.AddCluster(cluster1);
            tracker.AddCluster(cluster2);
        }
    }
}