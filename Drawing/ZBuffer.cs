﻿using static GolemApp.Extensions.Utils;

namespace GolemApp.Drawing
{
    /// <summary>
    /// Класс, представляющий z-буфер
    /// </summary>
    public class ZBuffer
    {
        private double[,] _zBuffer;

        private Size _size;

        public ZBuffer(Size size)
        {
            _size = size;

            InitializeZBuffer();
        }

        private void InitializeZBuffer()
        {
            _zBuffer = new double[_size.Width, _size.Height];
            
            for (int i = 0; i < _size.Width; i++)
                for (int j = 0; j < _size.Height; j++)
                    _zBuffer[i, j] = double.MinValue;
        }

        public double this[double x, double y]
        {
            get
            {                
                int _x = Floor(x), _y = Floor(y);
                
                if (_x > _size.Width - 1 || _x < 0 || _y < 0 || _y > _size.Height - 1)
                    return double.MaxValue;
                return _zBuffer[_x, _y];
            }
            set
            {
                _zBuffer[Floor(x), Floor(y)] = Floor(value);
            }
        }
    }
}