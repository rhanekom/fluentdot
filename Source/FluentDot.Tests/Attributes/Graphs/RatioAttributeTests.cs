/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Graphs {
    
    [TestFixture]
    public class RatioAttributeTests {

        [Test]
        public void ToDot_Ratio_Must_Provide_Correct_Output()
        {
            Assert.AreEqual(new RatioAttribute(new RatioType(Ratio.Auto)).ToDot(), "ratio=\"auto\"");
        }

        [Test]
        public void ToDot_Value_Must_Provide_Correct_Output() {
            Assert.AreEqual(new RatioAttribute(new RatioType(2.2)).ToDot(), "ratio=\"2.2\"");
        }
    }
}
