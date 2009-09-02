/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Common;

namespace FluentDot.Attributes.Graphs
{
    public class OutputMode : StringEnum, IDotElement
    {
        #region Constants

        public static readonly OutputMode BreadthFirst = new OutputMode("breadthfirst");
        public static readonly OutputMode NodesFirst = new OutputMode("nodesfirst");
        public static readonly OutputMode EdgesFirst = new OutputMode("edgesfirst");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputMode"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public OutputMode(string value) : base(value)
        {
            
        }

        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot()
        {
            return Value;
        }

        #endregion
    }
}
