/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Conventions;
using FluentDot.Expressions.Conventions;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Conventions {
    
    [TestFixture]
    public class ConventionCollectionModifiersExpressionTests {

        #region Public Members

        [Test]
        public void Setup_Should_Apply_Expression_And_Return_Instance()
        {
            var tracker = new ConventionTracker();
            Assert.AreSame(new ConventionCollectionModifiersExpression<ConventionCollectionModifiersExpressionTests>(
                this, tracker).Setup(x => x.AddType<TestNodeConvention>()), this);

            Assert.AreEqual(tracker.NodeConventions.Count, 1);
        }

        #endregion

        #region Private Members

        private class TestNodeConvention : INodeConvention {
            #region INodeConvention Members

            public bool ShouldApply(INodeInfo nodeInfo) {
                throw new System.NotImplementedException();
            }

            public void Apply(INodeInfo nodeInfo, FluentDot.Expressions.Nodes.INodeExpression nodeConfig) {
                throw new System.NotImplementedException();
            }

            #endregion
        }

        #endregion
    }
}
