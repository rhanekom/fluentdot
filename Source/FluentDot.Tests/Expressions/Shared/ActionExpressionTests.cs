/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using FluentDot.Expressions.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Shared
{
    [TestFixture]
    public class ActionExpressionTests {

        [Test]
        public void Is_Should_Invoke_Action_When_Called()
        {
            const string original = "bla";
            string expected = null;

            var actionExpression = new ActionExpression<string>(x => expected = x);
            actionExpression.Is(original);
            
            Assert.AreEqual(original, expected);
        }
    }
}