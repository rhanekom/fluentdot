/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

namespace FluentDot.Common
{
    /// <summary>
    /// A file service providing access to the file system.
    /// </summary>
    public interface IFileService {
        
        /// <summary>
        /// Provides an indication of whether the specified file exists on disk.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>An indication of whether the specified file exists.</returns>
        bool FileExists(string fileName);

        /// <summary>
        /// Writes the specified text to a file with the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file to write the text to.</param>
        /// <param name="text">The text to write to the file..</param>
        void WriteAllText(string fileName, string text);

        /// <summary>
        /// Deletes the file with the specified name.
        /// </summary>
        /// <param name="fileName">Name of the file to delete.</param>
        void Delete(string fileName);

        /// <summary>
        /// Gets the full path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The full path to the file or directory.</returns>
        string GetFullPath(string path);

        /// <summary>
        /// Creates a temporary file and returns the file name.
        /// </summary>
        /// <returns>The full path to the temporary file created.</returns>
        string CreateTemporaryFile();
    }
}