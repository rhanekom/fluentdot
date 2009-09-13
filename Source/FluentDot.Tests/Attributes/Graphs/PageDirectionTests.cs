/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Graphs;
using FluentDot.Attributes.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Graphs
{
    [TestFixture]
    public class PageDirectionTests
    {
        [Test]
        public void ToDot_Should_Combine_Major_And_Minor_Versions()
        {
            Assert.AreEqual(new PageDirection(HorizontalDirection.LeftToRight, VerticalDirection.TopToBottom).ToDot(),"LT");
            Assert.AreEqual(new PageDirection(HorizontalDirection.RightToLeft, VerticalDirection.BottomToTop).ToDot(), "RB");

            Assert.AreEqual(new PageDirection(VerticalDirection.BottomToTop, HorizontalDirection.RightToLeft).ToDot(), "BR");
            Assert.AreEqual(new PageDirection(VerticalDirection.BottomToTop, HorizontalDirection.LeftToRight).ToDot(), "BL");
        }

        [Test]
        public void Constants_Should_Be_Set_Up_Correctly()
        {
            Assert.AreEqual(PageDirection.BottomToTopLeftToRight.ToDot(), "BL");
            Assert.AreEqual(PageDirection.BottomToTopRightToLeft.ToDot(), "BR");
            Assert.AreEqual(PageDirection.LeftToRightBottomToTop.ToDot(), "LB");
            Assert.AreEqual(PageDirection.LeftToRightTopToBottom.ToDot(), "LT");
            Assert.AreEqual(PageDirection.RightToLeftBottomToTop.ToDot(), "RB");
            Assert.AreEqual(PageDirection.RightToLeftTopToBottom.ToDot(), "RT");
            Assert.AreEqual(PageDirection.TopToBottomLeftToRight.ToDot(), "TL");
            Assert.AreEqual(PageDirection.TopToBottomRightToLeft.ToDot(), "TR");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Should_Throw_If_Major_Null()
        {
            new PageDirection(null, VerticalDirection.BottomToTop);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Should_Throw_If_Minor_Null()
        {
            new PageDirection(VerticalDirection.BottomToTop, null);
        }
    }
}
