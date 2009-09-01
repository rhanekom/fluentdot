/*
 Copyright 2009 Riaan Hanekom

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Drawing;
using System.Windows.Forms;

namespace FluentDot.Samples.Forms {

    /// <summary>
    /// A scrollable picture box.
    /// </summary>
    public partial class ScrollablePictureBox : UserControl {

        #region Globals

        Image image;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="ScrollablePictureBox"/> class.
        /// </summary>
        public ScrollablePictureBox() {
            InitializeComponent();

            AutoScroll = true;
            AutoScrollMinSize = new Size(200, 200);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image {
            get { return image; }
            set {
                image = value;

                if (value != null)
                {
                    AutoScrollMinSize = new Size(image.Width, image.Height);
                }

                Invalidate();
            }
        }

        #endregion

        #region UserControl Members

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            var image = Image;

            if (image != null) {
                e.Graphics.DrawImage(image, new RectangleF(
                                                AutoScrollPosition.X,
                                                AutoScrollPosition.Y,
                                                image.Width,
                                                image.Height));
            }
        }

        #endregion
    }
}
