/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.IO;
using FluentDot.Configuration;
using NUnit.Framework;

namespace FluentDot.Tests.Configuration {
    
    [TestFixture]
    public class ConfigurationProviderTests {

        [Test]
        public void DotExecutableLocation_Default_Must_Be_Valid_Path()
        {
            string location = new ConfigurationProvider().DotExecutableLocation;
            Assert.AreEqual(Path.GetFullPath(location), location);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DotExecutableLocation_Must_Throw_When_Set_To_Null()
        {
            new ConfigurationProvider().DotExecutableLocation = null;
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DotExecutableLocation_Must_Throw_When_Set_To_Empty_String() {
            new ConfigurationProvider().DotExecutableLocation = String.Empty;
        }

        [Test]
        public void DotProcessTimeout_Default_Must_Be_Larger_Than_Zero()
        {
            int timeOut = new ConfigurationProvider().DotProcessTimeout;
            Assert.Greater(timeOut, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DotProcessTimeout_Must_Throw_When_Set_To_Smaller_Than_1()
        {
            new ConfigurationProvider().DotProcessTimeout = 0;
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DotProcessTimeout_Must_Throw_When_Set_To_Negative() {
            new ConfigurationProvider().DotProcessTimeout = -1;
        }

        [Test]
        public void DefaultFileFormat_Must_Not_Be_Null()
        {
            Assert.IsNotNull(new ConfigurationProvider().DefaultFileFormat);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void DefaultFileFormat_Must_Throw_If_Value_Null()
        {
            new ConfigurationProvider().DefaultFileFormat = null;
        }
    }
}
