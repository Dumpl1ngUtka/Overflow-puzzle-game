using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameMainScene.Flask
{
    public class Flask : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Transform _colorContainer;
        [SerializeField] private FlaskColor _colorPrefab;
        private int _index;
        private int _maxHeight;
        private int[] _colorIndexes;
        private FlaskColor[] _colors;
        private ColorScheme _colorScheme;
        
        public Action<int> OnClicked;
        
        public void Init(int index, int maxHeight, ColorScheme colorScheme)
        {
            _index = index;
            _maxHeight = maxHeight;
            _colorScheme = colorScheme;
            _colors = CreateColorCells(maxHeight);
            _colorIndexes = new int[maxHeight];
        }

        public void Render(int[] colors)
        {
            for (var index = 0; index < colors.Length; index++)
            {
                if (colors[index] != _colorIndexes[index])
                {
                    _colorIndexes[index] = colors[index];
                    if (colors[index] != 0)
                        _colors[index].SetColor(_colorScheme.GetColorByIndex(colors[index]));
                    else
                        _colors[index].ResetColor();
                }
            }
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(_index);
        }
        
        private FlaskColor[] CreateColorCells(int colorCount)
        {
            var colors = new FlaskColor[colorCount];
            for (var i = 0; i < colorCount; i++)
            {
                var color = Instantiate(_colorPrefab, _colorContainer);
                color.Init();
                colors[i] = color;
            }
            return colors;
        }
    }
}