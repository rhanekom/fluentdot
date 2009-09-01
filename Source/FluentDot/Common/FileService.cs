/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.IO;

namespace FluentDot.Common
{
    /// <summary>
    /// A concrete implementation of a <see cref="IFileService"/>.
    /// </summary>
    public class FileService : IFileService
    {
        #region IFileService Members

        /// <summary>
        /// Provides an indication of whether the specified file exists on disk.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// An indication of whether the specified file exists.
        /// </returns>
        public bool FileExists(string fileName) {
            return File.Exists(fileName);
        }

        /// <summary>
        /// Writes the specified text to a file with the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file to write the text to.</param>
        /// <param name="text">The text to write to the file..</param>
        public void WriteAllText(string fileName, string text) {
            File.WriteAllText(fileName, text);
        }

        /// <summary>
        /// Deletes the file with the specified name.
        /// </summary>
        /// <param name="fileName">Name of the file to delete.</param>
        public void Delete(string fileName)
        {
            File.Delete(fileName);
        }

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The full path to the file or directory.</returns>
        public string GetFullPath(string path)
        {
            return Path.GetFullPath(path);
        }

        /// <summary>
        /// Creates a temporary file and returns the file name.
        /// </summary>
        /// <returns>
        /// The full path to the temporary file created.
        /// </returns>
        public string CreateTemporaryFile()
        {
            return Path.GetTempFileName();
        }

        #endregion
    }
}