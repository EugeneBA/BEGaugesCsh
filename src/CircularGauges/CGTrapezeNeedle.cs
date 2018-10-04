using System.Drawing;
using System.Drawing.Drawing2D;

namespace CircularGauges
{
    public class CGTrapezeNeedle:CGNeedle
    {
        public CGTrapezeNeedle(CGControl parent) : base(parent)
        {
            _aspect = 0.5f;
        }

        private float _aspect;

        public float Aspect
        {
            get => _aspect;
            set
            {
                value = Helper.Bound(0.0f, value, 1.0f);
                if (_aspect == value)
                    return;
                _aspect = value;
                Update();
            }
        }

        public override void draw(Graphics g)
        {
            // Begin graphics container.
            var state = g.BeginContainer();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var center = Parent.Center();
            g.TranslateTransform(center.X,center.Y);
            float deg = GetDegFromValue(CurrentValue);
            g.RotateTransform(270 - deg);

            
                var r = Parent.Radius();
                var origin = RPosToPoints(r, _rPos);
                var length = RPosToPoints(r, RLength);
                var width = RPosToPoints(r, RWidth);
                var smallwidth = width * Aspect;

                PointF[] points = {
                new PointF(-width, origin),
                new PointF(-smallwidth, origin + length),
                new PointF(smallwidth, origin + length),
                new PointF(width, origin)};
            //using (var brush = new PathGradientBrush(points))
            //{
            //    brush.CenterColor = Color;
            //    Color[] colors = { Color.Gray};
            //    brush.SurroundColors = colors;
            //    g.FillPolygon(brush, points);
            //}

            using (var brush = new SolidBrush(Color))
            //using (var pen = new Pen(Color))
            {
                g.FillPolygon(brush, points);
                //g.DrawPolygon(pen,points);
            }

            g.EndContainer(state);
        }
    }
}
