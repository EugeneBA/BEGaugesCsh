using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularGauges
{
    public abstract class CGNeedle:CGScale
    {
        protected CGNeedle(CGControl parent) : base(parent)
        {
            _currentValue = 0;
            _rPos = 0;
            _rLength = 0.9f;
            _rWidth = 5;
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

        private float _currentValue;

        public float CurrentValue
        {
            get => _currentValue;
            set
            {
                value = Helper.Bound(_minValue, value, _maxValue);

                if (_currentValue == value)
                    return;

                _currentValue = value;
                
                Update();
            }
        }
    }
}
