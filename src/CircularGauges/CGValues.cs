using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularGauges
{
    public class CGValues:CGScale
    {
        public CGValues(CGControl parent) : base(parent)
        {
            _step = 10;
            //_correctPos = false;
            _fontBold = false;
        }

        private float _rFontSize;

        public float RFontSize
        {
            get => _rFontSize;
            set
            {
                _rFontSize = value;
                Update();
            }
        }

        private bool _fontBold;

        public bool FontBold
        {
            get => _fontBold;
            set
            {
                _fontBold = value;
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

            RectangleF rect = Parent.Bounds;

            Font font = new Font( Parent.Font.FontFamily, RPosToPoints(r, _rFontSize), FontBold?FontStyle.Bold:FontStyle.Regular);
            
            var brush = new SolidBrush(Color);
            for (float val = _minValue; val <= _maxValue; val += _step)
            {
                float deg = GetDegFromValue(val);
                PointF pt = Parent.Point(RPosToPoints(r, _rPos), deg);

                string strVal = val.ToString(CultureInfo.CurrentCulture);
                var sz = g.MeasureString(strVal, font);
                RectangleF txtRect = new RectangleF(new PointF(0,0), sz );
                Helper.MoveCenter(ref txtRect,pt);
                //if (_correctPos)
                //    CGWidget::SetInRect(rect, txtRect);
                g.DrawString(strVal,font,brush,txtRect);
            }
    }
    }
}
