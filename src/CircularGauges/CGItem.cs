using System.Drawing;

namespace CircularGauges
{
    public abstract class CGItem
    {
        protected CGItem(CGControl parent)
        {
            Parent = parent;
        }

        public CGControl Parent { get; }

        protected void Update()
        {
            Parent.Invalidate();
        }

        public abstract void draw(Graphics g);

        private float _rPos;

        public float RPos
        {
            get => _rPos;
            set
            {
                _rPos = value;
                Update();
            }
        }

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                Update();
            }
        }

        protected RectangleF AdjustRect(RectangleF rect, float rpos)
        {
            float radius = Parent.Radius();
            float offset = radius - RPosToPoints(radius, rpos);
            var newRec = RectangleF.Inflate(rect,-offset,-offset);
            newRec.Offset(offset,offset);
            return newRec;
        }

        protected float RPosToPoints(float r, float rpos)
        {
            if (rpos <= 0)
                return 0.0f;
            if (rpos >= 1.45)
                return rpos;

            return r * rpos;
        }
    }
}
