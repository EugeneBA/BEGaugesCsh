using System;
using System.Drawing;

namespace CircularGauges
{
    public class CGArc : CGScale
    {
        public CGArc(CGControl parent) : base(parent)
        {
            _rWidth = 3;
        }

        private float _rWidth;

        public float RWidth
        {
            get => _rWidth;
            set
            {
                _rWidth = value;
                Update();
            }
        }

        public override void draw(Graphics g)
        {
            float r = Parent.Radius();

            RectangleF arcRect = AdjustRect(Parent.GaugeFullRect(), RPos);

            if (arcRect.IsEmpty)
                return;

            using (var pen = new Pen(Color, RPosToPoints(r, RWidth)))
            {

                //painter->drawArc(arcRect, 16 * _minDegree, 16 * (_maxDegree - _minDegree));

                g.DrawArc(pen,arcRect,-_minDegree, -(_maxDegree - _minDegree));
            }
        }
    }
}
