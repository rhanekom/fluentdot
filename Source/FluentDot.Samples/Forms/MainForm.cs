/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using FluentDot.Execution;
using FluentDot.Samples.Core.Demos;

namespace FluentDot.Samples.Forms
{
    public partial class MainForm : Form {

        #region Construction

        public MainForm() {
            InitializeComponent();

            LoadDemos();
        }

        #endregion

        #region Events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void listView_ItemActivate(object sender, EventArgs e) {
            if (listView.SelectedItems.Count > 0)
            {
                ActivateDemo(listView.SelectedItems[0].Tag as IGraphDemo);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("FluentDot Samples");
        }

        #endregion

        #region Private Members

        private void ActivateDemo(IGraphDemo demo) {
            if (demo != null)
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                try {
                    string dot;
                    pictureBox.Image = demo.DrawGraph(out dot);

                    tbDot.Text = dot;
                } catch (Exception ex) {
                    MessageBox.Show(
                        "Error on generating graph : " + ex.Message +
                        "  Please ensure that graphviz is installed, and that the configured location is correct.",
                        "FluentDot.Samples", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } 
                finally
                {
                    stopWatch.Stop();

                    TimeSpan elapsedTime = stopWatch.Elapsed;
                    timeStatusLabel.Text = String.Format("Time taken : {0}ms ({1} seconds)",
                                                         elapsedTime.TotalMilliseconds, elapsedTime.TotalSeconds);
                    timeStatusLabel.Visible = true;
                }
            }
        }

        private void LoadDemos() {
            listView.Items.Clear();
            listView.Groups.Clear();

            var groups = new Dictionary<DemoType, ListViewGroup>();

            foreach (DemoType value in Enum.GetValues(typeof(DemoType)))
            {
                var group = new ListViewGroup(value.ToString(), HorizontalAlignment.Left);
                listView.Groups.Add(group);
                groups.Add(value, group);
            }

            var demos = DemoRegister.GetDemos();

            for (int i = 0; i < demos.Count; i++)
            {
                var demo = demos[i];

                var item = new ListViewItem(demo.FriendlyName) {
                    ToolTipText = demo.Description, 
                    Tag = demo,
                    ImageIndex = 0,
                    Group = groups[demo.Type]
                };

                listView.Items.Add(item);
            }
        }

        #endregion

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            var options = new Options();
            options.ShowDialog();
        }
    }
}