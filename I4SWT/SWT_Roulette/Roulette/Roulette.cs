using System;
using System.Collections.Generic;

namespace Roulette
{
    public class Roulette
    {
        private readonly List<Field> _fields;
        private Field _result;
        private IRandom _random;

        public Roulette(IFieldFactory FF, IRandom R)
        {
            _fields = FF.CreateFields();
            _random = R;
        }

        public void Spin()
        {
            var n = (uint)_random.Next(0, _fields.Count);
            _result = _fields[(int)n];
        }

        public Field GetResult()
        {
            return _result;
        }
    }
}

