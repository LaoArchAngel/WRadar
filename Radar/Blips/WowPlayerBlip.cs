using System.Drawing;
using System.Drawing.Drawing2D;
using BlackRain.WowObjects;

namespace Radar.Blips
{
    internal class WowPlayerBlip : WowUnitBlip
    {
        #region Properties

        protected override Color BlipColor
        {
            get { return BlipObject.IsMe ? Settings.Colors.PlayerMe : Settings.Colors.PlayerSame; }
        }

        public new WowPlayer BlipObject { get; set; }

        #endregion

        #region Constructors

        public WowPlayerBlip(WowPlayer unit) : base(unit)
        {
            BlipObject = unit;
        }

        #endregion

        #region Methods

        protected override void DrawShape(GraphicsPath g)
        {
            g.AddPolygon(new[]
                             {
                                 new Point(TOTAL_WIDTH/2, TOTAL_HEIGHT/2),
                                 new Point(TOTAL_WIDTH, TOTAL_HEIGHT),
                                 new Point(0, TOTAL_HEIGHT)
                             });
        }

        #endregion
    }
}