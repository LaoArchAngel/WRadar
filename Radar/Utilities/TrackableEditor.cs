using System;
using System.Windows.Forms;
using Radar.Tracking;

namespace Radar.Utilities
{
    internal partial class TrackableEditor : Form
    {
        #region Properties

        private string OriginalName { get; set; }
        private string OriginalPattern { get; set; }
        private Trackable ToEdit { get; set; }

        #endregion

        #region Constructors

        public TrackableEditor(Trackable toEdit)
        {
            InitializeComponent();

            ToEdit = toEdit;
            OriginalName = toEdit.Name;
            OriginalPattern = toEdit.Pattern;
            _namePatternTxtBx.Text = toEdit.Pattern;
            _nameTxtBx.Text = string.IsNullOrEmpty(toEdit.Name) ? "NameMe!" : toEdit.Name;
        }

        #endregion

        #region Events

        private void PatternChanged(object sender, EventArgs e)
        {
            ToEdit.Pattern = _namePatternTxtBx.Text;
        }

        private void NameChanged(object sender, EventArgs e)
        {
            ToEdit.Name = _nameTxtBx.Text;
        }

        private void TryClose(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (ValidateValues()) Close();
                    break;
                case Keys.Escape:
                    ToEdit.Pattern = OriginalPattern;
                    ToEdit.Name = OriginalName;
                    Close();
                    break;
            }
        }

        #region Methods

        private bool ValidateValues()
        {
            if (String.IsNullOrEmpty(_nameTxtBx.Text))
            {
                _nameTxtBx.Select();
                return false;
            }

            if (string.IsNullOrEmpty(_namePatternTxtBx.Text))
            {
                _namePatternTxtBx.Select();
                return false;
            }

            return true;
        }

        #endregion

        #endregion
    }
}