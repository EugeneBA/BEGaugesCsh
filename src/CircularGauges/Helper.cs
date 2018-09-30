using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularGauges
{
    public static class Helper
    {
        public static PointF Center(this RectangleF rect) => new PointF((rect.Left + rect.Right) * 0.5f, (rect.Top + rect.Bottom) * 0.5f);

        public static void MoveCenter(ref RectangleF rect, PointF pos)
        {
            var center = rect.Center();
            rect.Offset(pos.X-center.X,pos.Y-center.Y);
        }
    }
}
