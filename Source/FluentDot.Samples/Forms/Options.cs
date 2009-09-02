/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Windows.Forms;
using FluentDot.Samples.Properties;

namespace FluentDot.Samples.Forms {
    public partial class Options : Form {
        public Options() {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e) {
            Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
            Settings.Default.DotLocation = tbDotLocation.Text;
            Fluently.Configure(x => x.DotFilePath.Is(tbDotLocation.Text));
            Close();
        }

        private void btnChooseFile_Click(object sender, System.EventArgs e) {
            var fileDialog = new OpenFileDialog {Filter = "dot | dot.exe"};

            if (fileDialog.ShowDialog() == DialogResult.OK) {
                tbDotLocation.Text = fileDialog.FileName;
            }
        }

        private void Options_Load(object sender, System.EventArgs e) {
            tbDotLocation.Text = Settings.Default.DotLocation;
        }
    }
}
