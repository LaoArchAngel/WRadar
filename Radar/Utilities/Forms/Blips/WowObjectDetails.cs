using System.Windows.Forms;
using BlackRain.WowObjects;

namespace Radar.Utilities.Forms.Blips
{
    public partial class WowObjectDetails : Form
    {
    	#region Fields
    	private static readonly WowObjectDetails _detailForm = new WowObjectDetails();
    	#endregion

    	#region Properties
        public static WowObjectDetails DetailForm
        {
            get { return _detailForm; }
        }
        
        public WowObject DetailObject { get; set; }
        #endregion

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
