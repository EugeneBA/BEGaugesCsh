using System.Drawing;
using System.Drawing.Drawing2D;

namespace CircularGauges
{
    public class CGTriangleNeedle : CGNeedle
    {
        public CGTriangleNeedle(CGControl parent) : base(parent)
        {
        }

        public override void draw(Graphics g)
        {
            var state = g.BeginContainer();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var center = Parent.Center();
            g.TranslateTransform(center.X, center.Y);
            float deg = GetDegFromValue(CurrentValue);
            g.RotateTransform(270 - deg);


            var r = Parent.Radius();
            var origin = RPosToPoints(r, _rPos);
            var length = RPosToPoints(r, RLength);
            var width = RPosToPoints(r, RWidth);

            PointF[] points = {
                new PointF(0, origin + length),
                new PointF(-width, origin),
                new PointF(width, origin)};

            using (var brush = new SolidBrush(Color))
            {
                g.FillPolygon(brush, points);
            }

            g.EndContainer(state);
        }
    }
}
