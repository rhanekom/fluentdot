/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.IO;
using System.Security.Cryptography;

namespace FluentDot.Samples.Exporter
{
    public class FileHasher {
    
        public bool AreSame(string file1, string file2)
        {
            return Convert.ToBase64String(GetHash(file1)) == Convert.ToBase64String(GetHash(file2));
        }
        
        public byte[] GetHash(string filePath) {
            MD5 md5 = new MD5CryptoServiceProvider();

            using (var stream = File.OpenRead(filePath)) {
                return md5.ComputeHash(stream);
            }
        }
    }
}