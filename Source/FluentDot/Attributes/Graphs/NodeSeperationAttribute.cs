/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;

namespace FluentDot.Attributes.Graphs
{
    /// <summary>
    /// An attribute that sets the minimum space between to adjacent nodes in the same rank, in inches.
    /// </summary>
    public class NodeSeperationAttribute : AbstractDotAttribute
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NodeSeperationAttribute"/> class.
        /// </summary>
        /// <param name="inches">The inches.</param>
        /// <exception cref="ArgumentOutOfRangeException">When inches is less than 0.02.</exception>
        public NodeSeperationAttribute(double inches)
            : base("nodesep", inches, false)
        {
            if (inches < 0.02)
            {
                throw new ArgumentOutOfRangeException("inches", "Node seperation can not be less than 0.02 inches.");
            }
        }

        #endregion
    }
}