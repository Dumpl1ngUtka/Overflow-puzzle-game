using GameMainScene.Flask;
using Services.SceneControlService;
using UnityEngine;

namespace GameMainScene
{
    public class GameSceneController : SceneController
    {
        [SerializeField] private Flask.Flask _flaskPrefab;
        [SerializeField] private Transform _flaskContainer;
        private GameSceneModel _model;
        private GameSceneView _view;
        
        protected override void OnEnter()
        {
            var TMPCOLORSHEME = new ColorScheme(Color.yellow, Color.red, Color.green, Color.blue, Color.black, Color.cyan, Color.grey, Color.magenta);
            
            _model = new GameSceneModel();
            _view = TryGetComponent<GameSceneView>(out var view) ? 
                view : gameObject.AddComponent<GameSceneView>();
            _view.Init(_model.FlaskCount, _model.FlaskHeight, _flaskPrefab, _flaskContainer, TMPCOLORSHEME);

            SubscribeToFlask();

            _view.RenderAll(_model.Map);
        }

        protected override void OnExit()
        {
        }

        private void SubscribeToFlask()
        {
            foreach (var flask in _view.Flasks)
            {
                flask.OnClicked += flaskIndex => _model.ClickOnFlask(flaskIndex);
                flask.OnClicked += flaskIndex => _view.Render(flaskIndex, _model.Map);
            }
        }
    }
}