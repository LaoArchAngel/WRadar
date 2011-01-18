using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BlackRain.Common.Contracts;
using BlackRain.Common.Objects;
using Radar.Settings;
using Radar.Tracking;

namespace Radar.Blips
{
    public abstract partial class WowBlip : Control
    {
        #region Constants

        protected const int TOTAL_WIDTH = 14;
        protected const int TOTAL_HEIGHT = 14;

        #endregion

        #region Fields

        private bool _tracked = false;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the color of this blip
        /// <para>This should get the color defined by the user for its type.</para>
        /// </summary>
        protected abstract Color BlipColor { get; }

        /// <summary>
        /// Gets the WowObject that this blip represents.
        /// </summary>
        public virtual WowObject BlipObject { get; private set; }

        /// <summary>
        /// Gets whether this blip is tracked.  Default of boolean is false.
        /// </summary>
        public bool Tracked
        {
            get
            {
                _tracked = Settings.Tracking.TrackingLists.Exists(t => t.IsTracked(BlipObject, _tracked));
                return _tracked;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates a new WowBlip control.  Can only be called by child classes.
        /// </summary>
        /// <param name="wowObject">WoW Object this blip represents.  The type of this object will determine the
        /// polymorphic properties of the instance blip.</param>
        protected WowBlip(WowObject wowObject)
        {
            BlipObject = wowObject;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            objectInfo.Text = string.Format("{0} | {1}",
                                            wowObject is INamed ? ((INamed) wowObject).Name : wowObject.ToString(),
                                            wowObject.Type);
        }

        #endregion

        #region Methods

        #region Abstract

        /// <summary>
        /// Draw the shape of the blip's body onto the supplied Graphics object.
        /// </summary>
        /// <param name="g">Graphics object being used by the control.</param>
        /// <remarks>Shape resolution 8x8, starts at 5,5</remarks>
        protected abstract void DrawShape(GraphicsPath g);

        #endregion

        #region Protected

        protected virtual void DrawHighlight(GraphicsPath graphicsPath, Graphics graphics)
        {
            if (!Tracked) return;

            using (var hi = new GraphicsPath())
            {
                hi.AddEllipse(0, 0, TOTAL_WIDTH, TOTAL_HEIGHT);
                graphicsPath.AddPath(hi, true);
            }
        }
        
        /// <summary>
        /// Handles the Paint event for this control
        /// <para>Inheriting objects should overwrite this method to draw the actual blip image.  This is 
        /// can be completely dependant on the blip type.  The color should be BlipColor, which should also
        /// be defined by the child object (constructor would be your best bet).</para>
        /// </summary>
        /// <param name="paintEventArgs">Arguments from the parent's paint event.</param>
        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            if(Settings.Screen.Exclusive && !Tracked)
                return;

            var g = new GraphicsPath();
            var matrix = new Matrix();
            paintEventArgs.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //g.SmoothingMode = SmoothingMode.HighQuality;

            // Rotate negative degrees when drawing.
            //g.ResetTransform();
            //g.TranslateTransform(-Width/2F, -Height/2F, MatrixOrder.Append);
            //g.RotateTransform(-Utilities.MathFunctions.RadianToDegree(BlipObject.Facing), MatrixOrder.Append);
            //g.TranslateTransform(Width/2F, Height/2F, MatrixOrder.Append);

            g.FillMode = FillMode.Alternate;
            
            // Draw our direction.
            using (var dir = new GraphicsPath())
            {
                dir.AddLine(TOTAL_WIDTH/2, 0, TOTAL_WIDTH/2, TOTAL_HEIGHT/2);
                dir.Widen(new Pen(Brushes.Black));
                g.AddPath(dir, true);
            }

            //g.AddPolygon(new[]
            //                 {
            //                     new PointF(TOTAL_WIDTH/2, 1),
            //                     new PointF(TOTAL_WIDTH/3, TOTAL_HEIGHT/3 + 1),
            //                     new PointF(TOTAL_WIDTH * 2/3, TOTAL_HEIGHT/3 + 1)
            //                 });

            // Unique for each type.
            DrawShape(g);

            // Draw tracking highlight if applicable.
            DrawHighlight(g, paintEventArgs.Graphics);

            matrix.RotateAt(-Utilities.MathFunctions.RadianToDegree(BlipObject.Facing),
                            new PointF(TOTAL_WIDTH/2F, TOTAL_HEIGHT/2F),
                            MatrixOrder.Append);
            g.Transform(matrix);

            Region = new Region(g);
            g.Dispose();
            BackColor = BlipColor;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //PaintTracking(e.Graphics);
        }

        protected virtual void PaintTracking(Graphics graphics)
        {
            if (!Tracked) return;

            using (var b = new SolidBrush(Colors.Tracked))
            {
                graphics.FillEllipse(b, 0, TOTAL_HEIGHT/2, TOTAL_WIDTH, TOTAL_HEIGHT/2);
            }
        }

        protected void OpenTrackingMenu(object caller, EventArgs args)
        {
            Utilities.Tracking.ListEditor.ShowDialog();
        }

        /// <summary>
        /// Handles the click event for the context menu items.
        /// <para>Fires necessary events to start tracking the desired information.</para>
        /// <para>This method calls </para>
        /// </summary>
        /// <param name="caller">Hoping a <see cref="ToolStripMenuItem"/> object.</param>
        /// <param name="args">Empty arguments.</param>
        protected void SelectTracking(object caller, EventArgs args)
        {
            var clicked = caller as ToolStripMenuItem;

            if (clicked == null)
            {
                return;
            }

            if (clicked.Name == trackName.Name)
            {
                var named = BlipObject as INamed;

                if (named != null) Settings.Tracking.Default.Add(new Trackable {Pattern = named.Name, Name = named.Name});
            }
        }

        #endregion

        #region Public

        #endregion

        private void ShowDetails(object sender, EventArgs e)
        {
            Utilities.Radar.DetailForm.DetailObject = BlipObject;
            Utilities.Radar.DetailForm.ShowDialog();
        }

        #endregion
    }
}