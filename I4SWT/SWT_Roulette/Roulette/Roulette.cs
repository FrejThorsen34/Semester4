using System;
using System.Collections.Generic;

namespace Roulette
{
    public class Roulette : IRoulette
    {
        private readonly List<Field> _fields;
        private Field _result;
        private IRandom _random;

        public Roulette(IFieldFactory fieldFactory, IRandom randomizer)
        {
            _fields = fieldFactory.CreateFields();
            _result = _fields[0];
            _random = randomizer;
        }

        public void Spin()
        {
            // var n = (uint)_random.Next(0, _fields.Count);
            var n = (uint)_random.Next();
            _result = _fields[(int)n];
        }

        public Field GetResult()
        {
            return _result;
        }
    }
}
