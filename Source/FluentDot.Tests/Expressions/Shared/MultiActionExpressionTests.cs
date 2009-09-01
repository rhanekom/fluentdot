/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Expressions.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Shared {
    
    [TestFixture]
    public class MultiActionExpressionTests {

        [Test]
        public void Are_Applies_Action_Against_Value()
        {
            int result = 0;
            Action<int> action = x => result = x * 2;

            Assert.AreEqual(new MultiActionExpression<int, MultiActionExpressionTests>(5, this).Are(action), this);
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void Are_Applies_Post_Action()
        {
            int result = 0;
            Action<int> action = x => result = x * 2;
            Action<int> postAction = x => result = result * 2;

            Assert.AreEqual(new MultiActionExpression<int, MultiActionExpressionTests>(5, this, postAction).Are(action), this);
            Assert.AreEqual(result, 20);
        }
    }
}
