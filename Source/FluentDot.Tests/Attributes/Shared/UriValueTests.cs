/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Attributes.Shared;
using NUnit.Framework;

namespace FluentDot.Tests.Attributes.Shared
{
    [TestFixture]
    public class UriValueTests {

        [Test]
        public void Should_Save_Value()
        {
            var uri = new Uri("http://www.google.com");
            Assert.AreSame(new UriValue(uri).Value, uri);
        }

        [Test]
        public void ToDot_Should_Return_URL_Text()
        {
            var uri = new Uri("http://www.google.com");
            StringAssert.Contains("http://www.google.com", new UriValue(uri).ToDot());
        }
    }
}