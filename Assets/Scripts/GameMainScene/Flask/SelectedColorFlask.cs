using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GameMainScene.Flask
{
    public class SelectedColorFlask : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private FlaskColor _color;
        private ColorScheme _colorScheme;
        public Action OnClicked;


        public void Init(ColorScheme colorScheme)
        {
            _colorScheme = colorScheme;
            _color.Init();
        }

        public void Render(int colorIndex)
        {
            if (colorIndex == 0)
                _color.ResetColor();
            else
                _color.SetColor(_colorScheme.GetColorByIndex(colorIndex));
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke();
        }
    }
}