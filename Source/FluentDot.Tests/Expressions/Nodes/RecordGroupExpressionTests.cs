/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Entities;
using FluentDot.Expressions.Nodes;
using NUnit.Framework;

namespace FluentDot.Tests.Expressions.Nodes
{
    [TestFixture]
    public class RecordGroupExpressionTests {

        [Test]
        public void IsInverted_Sets_Group_as_Inverted()
        {
            var group = new RecordGroup();
            Assert.IsNotNull(new RecordGroupExpression(group).IsInverted());
            Assert.IsTrue(group.IsInverted);
        }
    }
}