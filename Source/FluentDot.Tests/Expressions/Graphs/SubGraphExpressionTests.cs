/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Graphs;
using FluentDot.Entities.Graphs;
using FluentDot.Expressions.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Graphs
{
    [TestFixture]
    public class SubGraphExpressionTests
    {
        #region Tests

        [Test]
        public void WithRank_Adds_Rank()
        {
            AssertAttributeAdded(x => x.WithRank(RankType.Minimum),
                typeof(RankAttribute), RankType.Minimum);
        }
        
        [Test]
        public void SubGraphs_Does_Not_Return_Null() {
            Assert.IsNotNull(new SubGraphExpression(new DirectedGraph()).SubGraphs);
        }

        #endregion

        #region Private Members

        private static void AssertAttributeAdded(Action<ISubGraphExpression> action, Type attributeType, object attributeValue)
        {
            AssertAttributeAdded(action, attributeType, attributeValue, null);
        }

        private static void AssertAttributeAdded(Action<ISubGraphExpression> action, Type attributeType, object attributeValue, Action<ISubGraph> customAsserts)
        {
            var graph = new DirectedGraph();
            var expression = new SubGraphExpression(graph);
            action(expression);

            var cluster = expression.SubGraph;

            Assert.AreEqual(cluster.Attributes.CurrentAttributes.Count, 1);

            var attribute = cluster.Attributes.CurrentAttributes[0];
            Assert.IsInstanceOfType(attributeType, attribute);
            Assert.AreEqual(attribute.Value, attributeValue);

            if (customAsserts != null)
            {
                customAsserts(expression.SubGraph);
            }
        }

        #endregion
    }
}