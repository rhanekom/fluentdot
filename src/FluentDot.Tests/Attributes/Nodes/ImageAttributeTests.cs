/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Nodes;
using FluentDot.Common;
using Moq;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Nodes
{
    [TestFixture]
    public class ImageAttributeTests {

        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            var fileService = new Mock<IFileService>();
            fileService.Setup(x => x.GetFullPath("a")).Returns("b");
            fileService.Setup(x => x.FileExists("a")).Returns(true);
         
            Assert.AreEqual(new ImageAttribute("a", fileService.Object).ToDot(), "image=\"b\"");
        }

        [Test]
        public void Constructor_Should_Throw_If_File_Does_Not_Exist() {
            var fileService = new Mock<IFileService>();
            fileService.Setup(x => x.GetFullPath("a")).Returns("b");
            fileService.Setup(x => x.FileExists("a")).Returns(false);

            Assert.Throws<ArgumentOutOfRangeException>(() => new ImageAttribute("a", fileService.Object));
        }
    }
}