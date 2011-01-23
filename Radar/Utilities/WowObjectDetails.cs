using System.Windows.Forms;
using BlackRain.WowObjects;

namespace Radar.Utilities
{
    public partial class WowObjectDetails : Form
    {
        public WowObject DetailObject { get; set; }

        internal WowObjectDetails()
        {
            InitializeComponent();
        }

        protected override void OnShown(System.EventArgs e)
        {
            base.OnShown(e);

            ViewGrid.SelectedObject = DetailObject;
        }
    }
}
