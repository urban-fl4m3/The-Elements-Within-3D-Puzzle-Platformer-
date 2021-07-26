using System;

// ReSharper disable once CheckNamespace
namespace Modules.Ticks.Runtime
{
    internal class VirtualTickController<TTick> where TTick : ITick
    {
        private TTick[] _ticks;

        private int _capacity;
        private int _length;

        public VirtualTickController()
        {
            ResetTicksArray();
        }
        
        public void Tick()
        {
            for (var i = 0; i < _length; i++)
            {
                var tick = _ticks[i];

                if (tick.Enabled)
                {
                    tick.Tick();
                }
            }
        }

        public void Add(TTick tick)
        {
            _ticks[_length] = tick;
            
            _length++;

            if (_length >= _capacity)
            {
                IncreaseTicksCapacity();
            }
        }

        public void Remove(TTick tick)
        {
            var removeAt = Array.IndexOf(_ticks, tick);

            _ticks[removeAt] = default;

            for (var i = removeAt; i< _length - 1; i++)
            {
                _ticks[i] = _ticks[i + 1];
            }

            _length--;
        }

        public void Clear()
        {
            ResetTicksArray();
        }

        private void ResetTicksArray()
        {
            _length = 0;
            _capacity = 4;
            _ticks = new TTick[_capacity];
        }

        private void IncreaseTicksCapacity()
        {
            _capacity *= 2;
            var largerTicks = new TTick[_capacity];

            for (var i = 0; i < _length - 1; i++)
            {
                largerTicks[i] = _ticks[i];
            }

            _ticks = largerTicks;
        }
    }
}