using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularGauges
{
    public partial class CGControl : UserControl
    {
        public CGControl()
        {
            InitializeComponent();
        }

        public  EnumCenterPos CenterPos { get; protected set; }= EnumCenterPos.CenterCenter;

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

        SizeF GaugeSize()
        {
            var size = Size;
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

        float Radius()
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

        public static double DegreesToRadians(double deg)
        {
            return deg * Math.PI / 180;
        }

        public static double RadiansToDegrees(double rad)
        {
            return rad * 180 / Math.PI;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }
}
