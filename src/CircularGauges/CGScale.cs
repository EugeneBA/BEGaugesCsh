using System;

namespace CircularGauges
{
    public abstract class CGScale:CGItem
    {
        protected CGScale(CGControl parent) : base(parent)
        {
            _minDegree = Parent.MinAngle;
            _maxDegree = Parent.MaxAngle;
            _minValue = 0;
            _maxValue = 100;
        }

        protected float _minValue;
        protected float _maxValue;
        protected float _minDegree;
        protected float _maxDegree;

        public void SetValueRange(float minValue, float maxValue)
        {
            if (!(minValue < maxValue))
                throw new ArgumentException("maxValue must be greater than minValue");
            _minValue = minValue;
            _maxValue = maxValue;
            Update();
        }

        public void SetDegreeRange(float minDegree, float maxDegree)
        {
            _minDegree = minDegree;
            _maxDegree = maxDegree;
            Update();
        }

        protected float GetDegFromValue(float value)
        {
            float a = (_maxDegree - _minDegree) / (_maxValue - _minValue);
            float b = -a * _minValue + _minDegree;
            return a * value + b;
        }
    }
}
