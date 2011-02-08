using System;
using System.Windows.Forms;
using Radar.Tracking;

namespace Radar.Utilities.Forms.Tracking
{
	internal partial class TrackableEditor : Form
	{
		#region Fields
		private static TrackingListEditor _listEditor = new TrackingListEditor();
		#endregion
		
		#region Properties
		public static TrackingListEditor ListEditor {
			get { return _listEditor; }
		}
		
		private Trackable ToEdit { get; set; }
		#endregion

		#region Constructors
		public TrackableEditor(Trackable toEdit)
		{
			InitializeComponent();

			ToEdit = toEdit;
			_namePatternTxtBx.Text = toEdit.Pattern;
			_nameTxtBx.Text = string.IsNullOrEmpty(toEdit.Name) ? "NameMe!" : toEdit.Name;
		}
		#endregion

		#region Methods
		private void PatternChanged(object sender, EventArgs e)
		{
			ToEdit.Pattern = _namePatternTxtBx.Text;
		}

		private void NameChanged(object sender, EventArgs e)
		{
			ToEdit.Name = _nameTxtBx.Text;
		}
		#endregion
	}
}
