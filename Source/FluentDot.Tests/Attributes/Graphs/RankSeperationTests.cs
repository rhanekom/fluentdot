/*
 Copyright 2009 Riaan Hanekom

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
    public class RankSeperationTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_Throws_If_All_Arguments_Are_Negative()
        {
            new RankSeperation(null, false);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Throws_If_Inches_Less_Than_0_02()
        {
            new RankSeperation(0.019, false);
        }

        [Test]
        public void ToDot_Produces_Correct_Output_When_Only_Inches_Specified()
        {
            Assert.AreEqual(new RankSeperation(3.2, false).ToDot(), "3.2");
        }

        [Test]
        public void ToDot_Produces_Correct_Output_When_Only_Equally_Specified()
        {
            Assert.AreEqual(new RankSeperation(null, true).ToDot(), "equally");
        }

        [Test]
        public void ToDot_Produces_Correct_Output_When_Equally_And_Inches_Specified()
        {
            Assert.AreEqual(new RankSeperation(3.11, true).ToDot(), "3.11 equally");
        }
    }
}
