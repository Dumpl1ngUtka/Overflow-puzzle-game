using GameMainScene.Flask;
using UnityEngine;

namespace GameMainScene
{
    public class GameSceneView : MonoBehaviour
    {
        [SerializeField] private SelectedColorFlask _selectedColor;
        [SerializeField] private Flask.Flask _flaskPrefab;
        [SerializeField] private Transform _flaskContainer;
        private int _flaskHeight;
        public Flask.Flask[] Flasks {get; private set;} 
        public SelectedColorFlask SelectedColorFlask => _selectedColor;
        
        
        public void Init(int flaskCount, int flaskHeight, ColorScheme colorScheme)
        {
            _flaskHeight = flaskHeight;
            _selectedColor.Init(colorScheme);
            
            ClearContainer();
            CreateFlasks(flaskCount, flaskHeight, colorScheme);       
        }

        public void RenderAll(int[,] allColors)
        {
            for (var flaskIndex = 0; flaskIndex < Flasks.Length; flaskIndex++)
            {
                var colors = new int[_flaskHeight];
                for (var i = 0; i < _flaskHeight; i++) 
                    colors[i] = allColors[flaskIndex, i];
                Render(flaskIndex, colors);
            }
            RenderSelectedColor(0);
        }
        
        public void Render(int flaskIndex, int[,] allColors)
        {
            var colors = new int[_flaskHeight];
            for (var i = 0; i < _flaskHeight; i++) 
                colors[i] = allColors[flaskIndex, i];
            Render(flaskIndex, colors);
        }

        public void Render(int flaskIndex, int[] colors)
        {
            var flask = Flasks[flaskIndex];
            flask.Render(colors);
        }

        public void RenderSelectedColor(int colorIndex)
        {
            _selectedColor.Render(colorIndex);
        }

        private void CreateFlasks(int flaskCount, int flaskHeight, ColorScheme colorScheme)
        {
            Flasks = new Flask.Flask[flaskCount];
            for (var i = 0; i < flaskCount; i++)
            {
                var flask = Instantiate(_flaskPrefab, _flaskContainer);
                flask.Init(i, flaskHeight, colorScheme); 
                Flasks[i] = flask;
            }
        }
        
        private void ClearContainer()
        {
            foreach (Transform child in _flaskContainer) 
                Destroy(child.gameObject);
        }
    }
}