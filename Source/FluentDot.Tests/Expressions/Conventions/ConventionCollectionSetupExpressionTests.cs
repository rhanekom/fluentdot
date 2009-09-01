/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Expressions.Conventions;
using NUnit.Framework;
using FluentDot.Conventions;

namespace FluentDot.Tests.Expressions.Conventions
{
    [TestFixture]
    public class ConventionCollectionSetupExpressionTests
    {
        #region Tests

        [Test]
        public void AddType_Should_Create_Instance_And_Add_It_To_The_Tracker()
        {
            var tracker = new ConventionTracker();
            var expression = new ConventionCollectionSetupExpression(tracker);

            Assert.AreEqual(tracker.NodeConventions.Count, 0);
            Assert.AreEqual(expression.AddType<TestNodeConvention>(), expression);
            Assert.AreEqual(tracker.NodeConventions.Count, 1);

            Assert.AreEqual(tracker.EdgeConventions.Count, 0);
            Assert.AreEqual(expression.AddType<TestEdgeConvention>(), expression);
            Assert.AreEqual(tracker.EdgeConventions.Count, 1);
        }

        [Test]
        [ExpectedException(typeof(System.ArgumentException))]
        public void AddType_Should_Throw_For_Conventions_Other_Than_Edge_And_Node()
        {
            var tracker = new ConventionTracker();
            var expression = new ConventionCollectionSetupExpression(tracker);
            expression.AddType<DummyConvention>();
        }

        [Test]
        public void AddInstance_Should_Create_Instance_And_Add_It_To_The_Tracker() {
            var tracker = new ConventionTracker();
            var expression = new ConventionCollectionSetupExpression(tracker);

            Assert.AreEqual(tracker.NodeConventions.Count, 0);
            Assert.AreEqual(expression.AddInstance(new TestNodeConvention()), expression);
            Assert.AreEqual(tracker.NodeConventions.Count, 1);

            Assert.AreEqual(tracker.EdgeConventions.Count, 0);
            Assert.AreEqual(expression.AddInstance(new TestEdgeConvention()), expression);
            Assert.AreEqual(tracker.EdgeConventions.Count, 1);
        }

        [Test]
        [ExpectedException(typeof(System.ArgumentException))]
        public void AddInstance_Should_Throw_For_Conventions_Other_Than_Edge_And_Node() {
            var tracker = new ConventionTracker();
            var expression = new ConventionCollectionSetupExpression(tracker);
            expression.AddInstance(new DummyConvention());
        }

        #endregion

        #region Private Members

        private class DummyConvention : IConvention
        {
            
        }

        private class TestNodeConvention : INodeConvention
        {
            #region INodeConvention Members

            public bool ShouldApply(INodeInfo nodeInfo)
            {
                throw new System.NotImplementedException();
            }

            public void Apply(INodeInfo nodeInfo, FluentDot.Expressions.Nodes.INodeExpression nodeConfig)
            {
                throw new System.NotImplementedException();
            }

            #endregion
        }

        private class TestEdgeConvention : IEdgeConvention
        {
            #region IEdgeConvention Members

            public bool ShouldApply(IEdgeInfo nodeInfo)
            {
                throw new System.NotImplementedException();
            }

            public void Apply(IEdgeInfo edgeInfo, FluentDot.Expressions.Edges.IEdgeExpression edge)
            {
                throw new System.NotImplementedException();
            }

            #endregion
        }

        #endregion
    }
}
