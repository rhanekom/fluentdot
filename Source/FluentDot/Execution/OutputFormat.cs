/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using FluentDot.Common;

namespace FluentDot.Execution {

    /// <summary>
    /// An enumeration of output formats available in the dot executable.
    /// </summary>
    public class OutputFormat : StringEnum, ICommandParameter {

        #region Constants

        public static OutputFormat Canon = new OutputFormat("canon");
        public static OutputFormat ClientSideImageMap = new OutputFormat("cmap");
        public static OutputFormat Dot = new OutputFormat("dot");
        public static OutputFormat GD = new OutputFormat("gd");
        public static OutputFormat GD2 = new OutputFormat("gd2");
        public static OutputFormat GIF = new OutputFormat("gif");
        public static OutputFormat HPGL = new OutputFormat("hpgl");
        public static OutputFormat IMAP = new OutputFormat("imap");
        public static OutputFormat FrameMakerMIF = new OutputFormat("mif");
        public static OutputFormat MetaPost = new OutputFormat("mp");
        public static OutputFormat PCL5 = new OutputFormat("pcl");
        public static OutputFormat PIC = new OutputFormat("pic");
        public static OutputFormat Plain = new OutputFormat("plain");
        public static OutputFormat PNG = new OutputFormat("png");
        public static OutputFormat PostScript = new OutputFormat("ps");
        public static OutputFormat PostScriptWithPDFAnnotations = new OutputFormat("ps2");
        public static OutputFormat SVG = new OutputFormat("svg");
        public static OutputFormat VRML = new OutputFormat("vrml");
        public static OutputFormat VTX = new OutputFormat("vtx");
        public static OutputFormat WBMP = new OutputFormat("wbmp");

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputFormat"/> class.
        /// </summary>
        /// <param name="value">The value that this instance represents..</param>
        public OutputFormat(string value) : base(value)
        {
            // Nothing to do.
        }

        #endregion

        #region ICommandParameter Members

        /// <summary>
        /// Creates a textual representation of the command line parameter.
        /// </summary>
        /// <returns>
        /// A textual represetnation of the command line parameter.
        /// </returns>
        public string ToCommandLine() {
            return "-T" + Value;
        }

        #endregion
    }
}
