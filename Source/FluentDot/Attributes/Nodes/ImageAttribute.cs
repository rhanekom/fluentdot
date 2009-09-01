/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using FluentDot.Common;

namespace FluentDot.Attributes.Nodes
{
    /// <summary>
    /// An attribute that sets an image that should be used as node content.
    /// </summary>
    public class ImageAttribute : AbstractDotAttribute {

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAttribute"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public ImageAttribute(string filePath) : this(filePath, new FileService()) {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageAttribute"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileService">The file service.</param>
        public ImageAttribute(string filePath, IFileService fileService)
            : base("image", fileService.GetFullPath(filePath), true)
        {
            if (!fileService.FileExists(filePath)) {
                throw new ArgumentOutOfRangeException("filePath", "The specified file could not be found.");
            }
        }

        #endregion
    }
}