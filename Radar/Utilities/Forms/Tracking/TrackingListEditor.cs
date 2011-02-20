using System;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Radar.Tracking;
using RadarSettings = Radar.Settings;

namespace Radar.Utilities.Forms.Tracking
{
    public partial class TrackingListEditor : Form
    {
        #region Properties

        internal TrackingList SelectedList { get; private set; }
        internal static TrackingListEditor ListEditor = new TrackingListEditor();

        #endregion

        #region Constructors

        public TrackingListEditor()
        {
            InitializeComponent();

            SelectedList = RadarSettings.Tracking.Default;
            _listsCombo.DataSource = RadarSettings.Tracking.TrackingLists;
            _listsCombo.DisplayMember = "Name";
            _listsCombo.SelectedItem = SelectedList;

            _trackablesLstBx.DataSource = SelectedList.Trackables;
            _trackablesLstBx.DisplayMember = "Name";
            _trackablesLstBx.Refresh();
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the click event of the Delete button for trackables.
        /// </summary>
        /// <param name="sender">button</param>
        /// <param name="e">empty</param>
        private void DeleteTrackables(object sender, EventArgs e)
        {
            foreach (var trackable in
                from object selectedItem in _trackablesLstBx.SelectedItems select selectedItem as Trackable)
            {
                SelectedList.Trackables.Remove(trackable);
            }

            _trackablesLstBx.DataSource = null;
            _trackablesLstBx.DataSource = SelectedList;
            _trackablesLstBx.DisplayMember = "Name";
            _trackablesLstBx.Refresh();
        }

        private void EditTrackable(object sender, EventArgs e)
        {
            if (_trackablesLstBx.SelectedIndex < 0 || _trackablesLstBx.SelectedItems.Count > 1)
                return;

            var track = _trackablesLstBx.SelectedItem as Trackable;
            var te = new TrackableEditor(track);

            te.ShowDialog();
            _trackablesLstBx.DataSource = null;
            _trackablesLstBx.DataSource = SelectedList;
            _trackablesLstBx.DisplayMember = "Name";
            _trackablesLstBx.Refresh();
        }

        private void ListChanged(object sender, EventArgs e)
        {
            SelectedList = _listsCombo.SelectedItem as TrackingList;

            _trackablesLstBx.Items.Clear();
            _trackablesLstBx.DataSource = SelectedList == null ? null : SelectedList.Trackables;
            _trackablesLstBx.DisplayMember = "Name";
            _trackablesLstBx.Refresh();
        }

        private void NewTrackable(object sender, EventArgs e)
        {
            var track = new Trackable();
            var te = new TrackableEditor(track);

            te.ShowDialog();

            if (string.IsNullOrEmpty(track.Pattern) || string.IsNullOrEmpty(track.Name))
            {
                return;
            }

            SelectedList.Trackables.Add(track);

            _trackablesLstBx.DataSource = null;
            _trackablesLstBx.DataSource = SelectedList.Trackables;
            _trackablesLstBx.DisplayMember = "Name";
            _trackablesLstBx.Refresh();
        }

        private void ReloadInfo(object sender, EventArgs e)
        {
            _trackablesLstBx.DataSource = null;
            _trackablesLstBx.DataSource = SelectedList.Trackables;
            _trackablesLstBx.DisplayMember = "Name";
            _trackablesLstBx.Refresh();
        }

        private void KeyboardShortcuts(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    if (e.Control && !e.Alt)
                    {
                        NewTrackable(this, EventArgs.Empty);
                        break;
                    }
                    break;
                case Keys.Delete:
                    DeleteTrackables(this, EventArgs.Empty);
                    break;
                case Keys.Enter:
                    EditTrackable(this, EventArgs.Empty);
                    break;
            }
        }

        /// <summary>
        /// Handles the closing event for the list editor.
        /// <p>Saves all of the current lists to xml files.</p>
        /// </summary>
        /// <param name="sender">this</param>
        /// <param name="args">empty</param>
        private static void SaveLists(object sender, CancelEventArgs args)
        {
            try
            {
                foreach (var tlist in RadarSettings.Tracking.TrackingLists)
                {
                    TrackingList.Save(tlist);
                }
            }
            catch (Exception e)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Some or all of your tracking lists did not save correctly.");
                sb.AppendLine("Hit cancel to keep the tracking list editor open.\n");
                sb.Append(e.ToString());

                var res = MessageBox.Show(sb.ToString(), @"Error exporting tracking lists.", MessageBoxButtons.OKCancel,
                                          MessageBoxIcon.Warning);

                args.Cancel = res == DialogResult.Cancel;
            }
        }

        #endregion
    }
}