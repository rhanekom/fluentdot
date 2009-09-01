/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute to set the graph as concentrated - that is, to use edge concentrators.
    /// </summary>
    public class ConcentrateAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ConcentrateAttribute"/> class.
        /// </summary>
        /// <param name="concentrated">if set to <c>true</c> use edge concentrators.</param>
        public ConcentrateAttribute(bool concentrated)
            : base("concentrate", new BooleanValue(concentrated), false)
        {

        }

        #endregion
    }
}