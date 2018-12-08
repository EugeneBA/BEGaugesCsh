using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CircularGauges
{
    public partial class CGControl : UserControl
    {
        public CGControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public EnumCenterPos CenterPos { get; protected set; } = EnumCenterPos.CenterCenter;

        public float MinAngle
        {
            get
            {
                if (CenterPos == EnumCenterPos.CenterLeft)
                    return 90;
                if (CenterPos == EnumCenterPos.CenterRight)
                    return 270;
                if (CenterPos == EnumCenterPos.BottomLeft)
                    return 90;
                if (CenterPos == EnumCenterPos.BottomRight)
                    return 270;
                if (CenterPos == EnumCenterPos.BottomCenter)
                    return 180;
                return 270;
            }
        }

        public float MaxAngle
        {
            get
            {
                if (CenterPos == EnumCenterPos.CenterLeft)
                    return 90;
                if (CenterPos == EnumCenterPos.CenterRight)
                    return 90;
                if (CenterPos == EnumCenterPos.BottomLeft)
                    return 0;
                if (CenterPos == EnumCenterPos.BottomRight)
                    return 90;
                if (CenterPos == EnumCenterPos.BottomCenter)
                    return 0;
                return -90;
            }
        }

        public Rectangle PaddedRectangle
        {
            get
            {
                var rect = ClientRectangle;
                var pad = Padding;
                return new Rectangle(rect.X + pad.Left,
                    rect.Y + pad.Top,
                    rect.Width - (pad.Left + pad.Right),
                    rect.Height - (pad.Top + pad.Bottom));
            }
        }

        private SizeF GaugeSize()
        {
            var size = PaddedRectangle.Size;
            float w = size.Width;
            float h = size.Height;

            float r;
            switch (CenterPos)
            {
                case EnumCenterPos.CenterLeft:
                case EnumCenterPos.CenterRight:
                    r = Math.Min(w * 2, h);
                    return new SizeF(r * 0.5f, r);

                case EnumCenterPos.BottomCenter:
                    r = Math.Min(w, 2 * h);
                    return new SizeF(r, r * 0.5f);

                default:
                    r = Math.Min(w, h);
                    return new SizeF(r, r);
            }
        }

        public RectangleF GaugeFullRect()
        {
            SizeF gsize = GaugeSize();
            RectangleF res;
            switch (CenterPos)
            {
                case EnumCenterPos.CenterLeft:
                case EnumCenterPos.CenterRight:
                    res = new RectangleF(0, 0, gsize.Width * 2, gsize.Height);
                    break;

                case EnumCenterPos.BottomLeft:
                case EnumCenterPos.BottomRight:
                    res = new RectangleF(0, 0, gsize.Width * 2, gsize.Height * 2);
                    break;

                case EnumCenterPos.BottomCenter:
                    res = new RectangleF(0, 0, gsize.Width, gsize.Height * 2);
                    break;

                default:
                    res = new RectangleF(0, 0, gsize.Width, gsize.Height);
                    break;
            }

            Helper.MoveCenter(ref res, Center());
            return res;
        }

        public PointF Center()
        {
            RectangleF wrect = PaddedRectangle;
            //wrect.adjust(_padding,_padding,-_padding,-_padding);
            PointF center = wrect.Center();
            switch (CenterPos)
            {
                case EnumCenterPos.CenterLeft:
                    center.X = wrect.Left;
                    return center;
                case EnumCenterPos.CenterRight:
                    center.X = wrect.Right;
                    return center;

                case EnumCenterPos.BottomLeft:
                    return new PointF(wrect.Left, wrect.Bottom);
                case EnumCenterPos.BottomRight:
                    return new PointF(wrect.Right, wrect.Bottom);
                case EnumCenterPos.BottomCenter:
                    center.Y = wrect.Bottom;
                    return center;

                default:
                    return center;
            }
        }

        public float Radius()
        {
            var size = GaugeSize();

            switch (CenterPos)
            {
                case EnumCenterPos.CenterCenter:
                    return size.Height * 0.5f;

                case EnumCenterPos.BottomCenter:
                    return size.Height;

                default:
                    return size.Width;
            }
        }

        public PointF Point(float rpos, float deg)
        {
            //Q_ASSERT(rpos>=0);
            float rx = (float)(Math.Cos(DegreesToRadians(deg)) * rpos);
            float ry = (float)(-Math.Sin(DegreesToRadians(deg)) * rpos);

            var center = Center();
            return new PointF(center.X + rx, center.Y + ry);
        }

        public static double DegreesToRadians(double deg)
        {
            return deg * Math.PI / 180;
        }

        public static double RadiansToDegrees(double rad)
        {
            return rad * 180 / Math.PI;
        }

        public void AddItem(CGItem item, float rPos)
        {
            item.RPos = rPos;
            _items.Add(item);
        }

        public bool RemoveItem(CGItem item)
        {
            return _items.Remove(item);
        }

        private List<CGItem> _items = new List<CGItem>();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (var item in _items)
                item.draw(g);

            //var pen = new Pen(Color.Black);
            //g.DrawRectangle(pen,gaugeRect());
            //g.DrawRectangle(pen, rect());
        }
    }
}
