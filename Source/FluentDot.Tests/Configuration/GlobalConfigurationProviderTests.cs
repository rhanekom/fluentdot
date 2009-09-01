/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NUnit.Framework;
using FluentDot.Configuration;

namespace FluentDot.Tests.Configuration {
    
    [TestFixture]
    public class GlobalConfigurationProviderTests {

        [Test]
        public void Global_Configuration_Instance_Should_Not_Be_Null()
        {
            Assert.IsNotNull(GlobalConfiguration.Instance);
        }
    }
}
