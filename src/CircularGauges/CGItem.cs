using System.Drawing;

namespace CircularGauges
{
    public abstract class CGItem
    {
        protected CGItem(CGControl parent)
        {
            _parent = parent;
        }

        private readonly CGControl _parent;

        protected void Update()
        {
            _parent.Invalidate();
        }

        public abstract void draw(Graphics g);

        private float _rPos;

        public float rPos
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

        private RectangleF AdjustRect(RectangleF rect, float rpos)
        {
            float radius = _parent.Radius();
            float offset = radius - rPosToPoints(radius, rpos);
            var newRec = RectangleF.Inflate(rect,-offset,-offset);
            newRec.Offset(offset,offset);
            return newRec;
        }

        private float rPosToPoints(float r, float rpos)
        {
            if (rpos <= 0)
                return 0.0f;
            if (rpos >= 1.45)
                return rpos;

            return r * rpos;
        }
    }
}
