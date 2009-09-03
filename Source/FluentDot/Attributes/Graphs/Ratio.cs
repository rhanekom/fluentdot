/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Common;

namespace FluentDot.Attributes.Graphs {
    
    /// <summary>
    /// Specifies a growth or shrink strategy of the graph in terms of its ratio.
    /// </summary>
    public class Ratio : StringEnum, IDotElement {

        #region Constants

        /// <summary>
        /// If the size  attribute is set, node positions are scaled, separately in both x and y, so that the 
        /// final drawing exactly fills the specified size. 
        /// </summary>
        public static readonly Ratio Fill = new Ratio("fill");

        /// <summary>
        /// If the size attribute is set, dot attempts to compress the initial layout to fit in the given size. 
        /// This achieves a tighter packing of nodes but reduces the balance and symmetry.
        /// </summary>
        public static readonly Ratio Compress = new Ratio("compress");

        /// <summary>
        /// If the size attribute is set, and both the width and the height of the graph are less than the value 
        /// in size, node positions are scaled uniformly until at least one dimension fits size exactly. 
        /// This is distinct from using size as the desired size, as here the drawing is expanded before 
        /// edges are generated and all node and text sizes remain unchanged. 
        /// </summary>
        public static readonly Ratio Expand = new Ratio("expand");

        /// <summary>
        /// If the page attribute is set and the graph cannot be drawn on a single page, then size is set to an 
        /// ideal value. In particular, the size in a given dimension will be the smallest integral multiple of 
        /// the page size in that dimension which is at least half the current size. The two dimensions are then 
        /// scaled independently to the new size. 
        /// </summary>
        public static readonly Ratio Auto = new Ratio("auto");
        
        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="Ratio"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public Ratio(string value) : base(value) {
            
        }
      
        #endregion

        #region IDotElement Members

        /// <summary>
        /// Creates a textual Dot representation of this element.
        /// </summary>
        /// <returns>
        /// A textual Dot representation of this element.
        /// </returns>
        public string ToDot() {
            return Value;
        }

        #endregion
    }
}
