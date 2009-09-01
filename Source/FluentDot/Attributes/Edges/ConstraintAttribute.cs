/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Edges
{
    /// <summary>
    /// An attribute to set whether the edge should be considered in constraints or not.
    /// </summary>
    public class ConstraintAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstraintAttribute"/> class.
        /// </summary>
        /// <param name="constraint">if set to <c>true</c> then consider the edge for constraints.</param>
        public ConstraintAttribute(bool constraint)
            : base("constraint", new BooleanValue(constraint), false)
        {

        }

        #endregion
    }
}