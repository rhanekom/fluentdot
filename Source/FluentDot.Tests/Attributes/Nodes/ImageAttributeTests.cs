/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Nodes;
using FluentDot.Common;
using NUnit.Framework;
using Rhino.Mocks;

namespace FluentDot.Tests.Attributes.Nodes
{
    [TestFixture]
    public class ImageAttributeTests {

        [Test]
        public void ToDot_Should_Produce_Correct_Output()
        {
            var fileService = MockRepository.GenerateMock<IFileService>();
            fileService.Expect(x => x.GetFullPath("a")).Return("b");
            fileService.Expect(x => x.FileExists("a")).Return(true);
         
            Assert.AreEqual(new ImageAttribute("a", fileService).ToDot(), "image=\"b\"");
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_Should_Throw_If_File_Does_Not_Exist() {
            var fileService = MockRepository.GenerateMock<IFileService>();
            fileService.Expect(x => x.GetFullPath("a")).Return("b");
            fileService.Expect(x => x.FileExists("a")).Return(false);

            new ImageAttribute("a", fileService);
        }
    }
}