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
        
        /// <summary>
        /// Canon format.
        /// </summary>
        public static OutputFormat Canon = new OutputFormat("canon");

        /// <summary>
        /// A client side image map.
        /// </summary>
        public static OutputFormat ClientSideImageMap = new OutputFormat("cmap");

        /// <summary>
        /// Attributed dot.
        /// </summary>
        public static OutputFormat Dot = new OutputFormat("dot");

        /// <summary>
        /// GD format.
        /// </summary>
        public static OutputFormat GD = new OutputFormat("gd");

        /// <summary>
        /// GD2 format.
        /// </summary>
        public static OutputFormat GD2 = new OutputFormat("gd2");

        /// <summary>
        /// GIF format.
        /// </summary>
        public static OutputFormat GIF = new OutputFormat("gif");

        /// <summary>
        /// HPGL format.
        /// </summary>
        public static OutputFormat HPGL = new OutputFormat("hpgl");

        /// <summary>
        /// Server-side and client-side image map.
        /// </summary>
        public static OutputFormat IMAP = new OutputFormat("imap");

        /// <summary>
        /// Frame Maker MIF format.
        /// </summary>
        public static OutputFormat FrameMakerMIF = new OutputFormat("mif");

        /// <summary>
        /// MetaPost format.
        /// </summary>
        public static OutputFormat MetaPost = new OutputFormat("mp");

        /// <summary>
        /// PCL5 format.
        /// </summary>
        public static OutputFormat PCL5 = new OutputFormat("pcl");

        /// <summary>
        /// PIC format.
        /// </summary>
        public static OutputFormat PIC = new OutputFormat("pic");

        /// <summary>
        /// Simple text format.
        /// </summary>
        public static OutputFormat Plain = new OutputFormat("plain");

        /// <summary>
        /// Portable Network Graphics format.
        /// </summary>
        public static OutputFormat PNG = new OutputFormat("png");

        /// <summary>
        /// PostSCript format.
        /// </summary>
        public static OutputFormat PostScript = new OutputFormat("ps");

        /// <summary>
        /// PostScript for PDF.
        /// </summary>
        public static OutputFormat PostScriptWithPDFAnnotations = new OutputFormat("ps2");

        /// <summary>
        /// Scalable Vector Graphics format.
        /// </summary> 
        public static OutputFormat SVG = new OutputFormat("svg");

        /// <summary>
        /// Vector Markup Languager format.
        /// </summary>
        public static OutputFormat VML = new OutputFormat("vml");

        /// <summary>
        /// Virtual Reality Modeling Language format.
        /// </summary>
        public static OutputFormat VRML = new OutputFormat("vrml");

        /// <summary>
        /// VTX format.
        /// </summary>
        public static OutputFormat VTX = new OutputFormat("vtx");

        /// <summary>
        /// Wireless Bitmap format.
        /// </summary>
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
