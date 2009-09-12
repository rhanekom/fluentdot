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
    public class AspectValueTests {

        [Test]
        public void ToDot_Produces_Correct_Output_If_Only_Value_Was_Specified()
        {
            Assert.AreEqual(new AspectValue(2.2).ToDot(), "2.2");
        }

        [Test]
        public void ToDot_Produces_Correct_Output_If_Value_And_Passes_Was_Specified() {
            Assert.AreEqual(new AspectValue(1.33, 6).ToDot(), "1.33,6");
        }
    }
}
