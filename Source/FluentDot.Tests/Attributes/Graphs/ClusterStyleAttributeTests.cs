﻿/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using FluentDot.Attributes.Graphs;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Graphs
{
    [TestFixture]
    public class ClusterStyleAttributeTests {
        
        [Test]
        public void To_Dot_Should_Produce_Correct_Output_For_Edges() {
            Assert.AreEqual(new ClusterStyleAttribute(ClusterStyle.Filled).ToDot(), "style=\"filled\"");
        }
    }
}