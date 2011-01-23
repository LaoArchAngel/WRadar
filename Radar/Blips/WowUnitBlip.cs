using System.Drawing;
using System.Drawing.Drawing2D;
using BlackRain;
using BlackRain.WowObjects;

namespace Radar.Blips
{
    internal class WowUnitBlip : WowBlip
    {
        #region Properties

        /// <summary>
        /// Gets the correct color determined by the unit and certain of the flags.
        /// </summary>
        protected override Color BlipColor
        {
            get
            {
                if (BlipObject.SummonedBy > 0)
                {
                    return BlipObject.Health <= 0 ? Settings.Colors.PetDead : Settings.Colors.Pet;
                }

                return BlipObject.Health <= 0 ? Settings.Colors.UnitDead : Settings.Colors.Unit;
            }
        }

        public new WowUnit BlipObject { get; set; }

        public bool Target
        {
            get { return BlipObject.GUID == ObjectManager.Me.Target; }
        }

        #endregion

        #region Constructors

        public WowUnitBlip(WowUnit wowUnit) : base(wowUnit)
        {
            BlipObject = wowUnit;
        }

        #endregion

        #region Methods

        #region Protected

        protected override void DrawHighlight(GraphicsPath graphicsPath, Graphics graphics)
        {
            if (Target)
            {
                using (var p = new Pen(Settings.Colors.Tracked, 2))
                {
                    graphicsPath.Widen(p);
                }
                return;
            }

            base.DrawHighlight(graphicsPath, graphics);
        }

        protected override void DrawShape(GraphicsPath g)
        {
            g.AddEllipse(TOTAL_WIDTH/4, TOTAL_HEIGHT/2, TOTAL_WIDTH/2, TOTAL_HEIGHT/2);
            //g.AddClosedCurve(new[]
            //                     {
            //                         new Point(0, TOTAL_HEIGHT/2 - 1), new Point(TOTAL_WIDTH/2, TOTAL_HEIGHT),
            //                         new Point(TOTAL_WIDTH, TOTAL_HEIGHT/2 - 1)
            //                     });
        }

        protected override void PaintTracking(Graphics graphics)
        {
            if (!Target)
            {
                base.PaintTracking(graphics);
                return;
            }

            using (var b = new SolidBrush(BlipObject.Dead ? Settings.Colors.TargetDead : Settings.Colors.Target))
            {
                graphics.FillEllipse(b, TOTAL_WIDTH / 4, TOTAL_HEIGHT / 4 * 3, TOTAL_WIDTH / 4, TOTAL_HEIGHT / 4);
            }
        }

        #endregion

        #endregion
    }
}