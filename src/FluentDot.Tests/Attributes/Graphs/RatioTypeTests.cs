/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Graphs
{
    [TestFixture]
    public class RatioTypeTests
    {
        [Test]
        public void ToDot_Should_Return_Ratio_Value_If_Specified()
        {
            Assert.AreEqual(new RatioType(Ratio.Auto).ToDot(), Ratio.Auto.ToDot());
        }

        [Test]
        public void ToDot_Should_Return_Value_If_Specified()
        {
            Assert.AreEqual(new RatioType(2.3).ToDot(), "2.3");
        }

        [Test]
        public void Constructor_Value_Must_Throw_If_Value_Equal_To_0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RatioType(0));
        }

        [Test]
        public void Constructor_Value_Must_Throw_If_Value_Less_Than_0()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new RatioType(-1));
        }
    }
}
