using System.Drawing;
using System.Windows.Forms;

namespace Watchdog.Forms.Util
{
    class VerticalLabel : Label
    {
        private readonly int rotation;
        public VerticalLabel(int rotation)
        {
            this.rotation = rotation;
        }

        protected override void OnPaint(PaintEventArgs paintEvent)
        {
            Brush brush = new SolidBrush(Color.Black);
            paintEvent.Graphics.TranslateTransform(Width / 5, Height);
            paintEvent.Graphics.RotateTransform(rotation);
            paintEvent.Graphics.DrawString(Text, Font, brush, 0, 0);
        }
    }
}
