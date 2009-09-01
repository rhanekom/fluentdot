/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Execution {

    /// <summary>
    /// A command line parameter instance.
    /// </summary>
    public interface ICommandParameter {

        /// <summary>
        /// Creates a textual representation of the command line parameter.
        /// </summary>
        /// <returns>A textual represetnation of the command line parameter.</returns>
        string ToCommandLine();
    }
}
