using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularGauges
{
    public class CGTicks : CGScale
    {
        public CGTicks(CGControl parent) : base(parent)
        {
            _step = 10;
            _rLength = 5;
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

        private float _rLength;

        public float RLength
        {
            get => _rLength;
            set
            {
                _rLength = value;
                Update();
            }
        }

        private float _step;

        public float Step
        {
            get => _step;
            set
            {
                _step = value;
                Update();
            }
        }

        public override void draw(Graphics g)
        {
            float r = Parent.Radius();

            float origin = RPosToPoints(r, RPos);
            float length = RPosToPoints(r, RLength);
            float width = RPosToPoints(r, RWidth);
            using (var pen = new Pen(Color, width))
            {
                for (float val = _minValue; val <= _maxValue; val += _step)
                {
                    float deg = GetDegFromValue(val);
                    PointF start = Parent.Point(origin, deg);
                    PointF end = Parent.Point(origin + length, deg);

                    g.DrawLine(pen,start, end);
                }
            }
        }
    }
}
