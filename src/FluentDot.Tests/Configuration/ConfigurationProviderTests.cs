/*
 Copyright 2012 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Configuration;
using NUnit.Framework;

namespace FluentDot.Tests.Configuration {
    
    [TestFixture]
    public class ConfigurationProviderTests {

        [Test]
        public void DotExecutableLocation_Must_Throw_When_Set_To_Null()
        {
            Assert.Throws<ArgumentException>(() => new ConfigurationProvider().DotExecutableLocation = null);
        }

        [Test]
        public void DotExecutableLocation_Must_Throw_When_Set_To_Empty_String() {
            Assert.Throws<ArgumentException>(() => new ConfigurationProvider().DotExecutableLocation = String.Empty);
        }

        [Test]
        public void DotProcessTimeout_Default_Must_Be_Larger_Than_Zero()
        {
            int timeOut = new ConfigurationProvider().DotProcessTimeout;
            Assert.Greater(timeOut, 0);
        }

        [Test]
        public void DotProcessTimeout_Must_Throw_When_Set_To_Smaller_Than_1()
        {
            Assert.Throws<ArgumentException>(() => new ConfigurationProvider().DotProcessTimeout = 0);
        }

        [Test]
        public void DotProcessTimeout_Must_Throw_When_Set_To_Negative() {
            Assert.Throws<ArgumentException>(() => new ConfigurationProvider().DotProcessTimeout = -1);
        }

        [Test]
        public void DefaultFileFormat_Must_Not_Be_Null()
        {
            Assert.IsNotNull(new ConfigurationProvider().DefaultFileFormat);
        }

        [Test]
        public void DefaultFileFormat_Must_Throw_If_Value_Null()
        {
            Assert.Throws<ArgumentException>(() => new ConfigurationProvider().DefaultFileFormat = null);
        }
    }
}
