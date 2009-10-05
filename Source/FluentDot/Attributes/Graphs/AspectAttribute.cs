/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


namespace FluentDot.Attributes.Graphs {

    /// <summary>
    /// An attribute that changes the graph aspect ration in which the graph is rendered.
    /// </summary>
    public class AspectAttribute : AbstractDotAttribute<AspectValue> {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="AspectAttribute"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public AspectAttribute(AspectValue value)
            : base("aspect", value, true)
        {

        }

        #endregion
    }
}
