/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


namespace FluentDot.Attributes.Edges {

    /// <summary>
    /// An attribute that specifies where the edge should be connected to the node graphically.
    /// </summary>
    public class TailPortAttribute : AbstractDotAttribute<CompassPoint> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="TailPortAttribute"/> class.
        /// </summary>
        /// <param name="compassPoint">The compass point.</param>
        public TailPortAttribute(CompassPoint compassPoint)
            : base("tailport", compassPoint, true)
        {

        }

        #endregion
    }
}
