/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Windows.Forms;
using FluentDot.Samples.Forms;
using FluentDot.Samples.Properties;

namespace FluentDot.Samples {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Fluently.Configure(x => x.DotFilePath.Is(Settings.Default.DotLocation));

            Application.Run(new MainForm());
        }
    }
}
