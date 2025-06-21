using System;
using UnityEngine;

namespace GameMainScene.Flask
{
    public class ColorScheme
    {
        private readonly Color[] _colors;
        
        public ColorScheme(Color c1, Color c2, Color c3, Color c4, Color c5, Color c6, Color c7, Color c8)
        {
            _colors = new Color[8];
            _colors[0] = c1;
            _colors[1] = c2;
            _colors[2] = c3;
            _colors[3] = c4;
            _colors[4] = c5;
            _colors[5] = c6;
            _colors[6] = c7;
            _colors[7] = c8;
        }
        
        public ColorScheme(Color[] colors)
        {
            if (colors.Length != 8)
                throw new ArgumentException("colors.Length != 8");
            _colors = colors;
        }

        public Color GetColorByIndex(int index)
        {
            return _colors[index];
        }
    }
}