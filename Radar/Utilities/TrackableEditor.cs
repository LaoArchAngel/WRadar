using System;
using System.Windows.Forms;
using Radar.Tracking;

namespace Radar.Utilities
{
    internal partial class TrackableEditor : Form
    {
        private Trackable ToEdit { get; set; }

        public TrackableEditor(Trackable toEdit)
        {
            InitializeComponent();

            ToEdit = toEdit;
            _namePatternTxtBx.Text = toEdit.Pattern;
            _nameTxtBx.Text = string.IsNullOrEmpty(toEdit.Name) ? "NameMe!" : toEdit.Name;
        }

        private void PatternChanged(object sender, EventArgs e)
        {
            ToEdit.Pattern = _namePatternTxtBx.Text;
        }

        private void NameChanged(object sender, EventArgs e)
        {
            ToEdit.Name = _nameTxtBx.Text;
        }
    }
}
