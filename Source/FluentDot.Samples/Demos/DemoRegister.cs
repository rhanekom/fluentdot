/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentDot.Samples.Demos {
    
    public static class DemoRegister {

        public static IList<IGraphDemo> GetDemos()
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(IGraphDemo).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract)
                .Select(x => (IGraphDemo) Activator.CreateInstance(x))
                .OrderBy(x => (int) x.Type)
                .ToList();
        }
    }
}
