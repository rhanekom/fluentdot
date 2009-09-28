/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using FluentDot.Attributes.Shared;

namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute that, if set, allows edges between clusters.
    /// </summary>
    public class CompoundAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CompoundAttribute"/> class.
        /// </summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        public CompoundAttribute(bool value)
            : base("compound", new BooleanValue(value), true)
        {

        }

        #endregion
    }
}
