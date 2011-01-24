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
            g.AddPath(Settings.Screen.ShapePlayer, true);
        }

        #endregion
    }
}