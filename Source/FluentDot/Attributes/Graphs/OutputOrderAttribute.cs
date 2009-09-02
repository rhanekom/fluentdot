/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// Specifies the output order of the graph.
    /// </summary>
    public class OutputOrderAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputOrderAttribute"/> class.
        /// </summary>
        /// <param name="mode">The mode.</param>
        public OutputOrderAttribute(OutputMode mode) : base("outputorder", mode, true)
        {
            
        }

        #endregion
    }
}
