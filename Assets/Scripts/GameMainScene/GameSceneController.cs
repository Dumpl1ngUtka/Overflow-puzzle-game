using GameMainScene.Flask;
using Services.SceneControlService;
using UnityEngine;

namespace GameMainScene
{
    [RequireComponent(typeof(GameSceneView))]
    public class GameSceneController : SceneController
    {
        [SerializeField] private Color[] _colors;
        private GameSceneModel _model;
        private GameSceneView _view;
        
        protected override void OnEnter()
        {
            var TMPCOLORSHEME = new ColorScheme(_colors);
            
            _model = new GameSceneModel();
            _view = GetComponent<GameSceneView>();
            _view.Init(_model.FlaskCount, _model.FlaskHeight, TMPCOLORSHEME);

            SubscribeToFlask();

            _view.RenderAll(_model.Map);
        }

        protected override void OnExit()
        {
        }

        public void OnExitButtonClicked() => _model.Exit();
        
        public void OnRestartButtonClicked() => _model.Restart();

        private void SubscribeToFlask()
        {
            foreach (var flask in _view.Flasks)
            {
                flask.OnClicked += flaskIndex => _model.ClickOnFlask(flaskIndex);
                flask.OnClicked += flaskIndex => _view.Render(flaskIndex, _model.Map);
                flask.OnClicked += _ => _view.RenderSelectedColor(_model.SelectedColor);
            }
            //_view.SelectedColorFlask.OnClicked += () => _
        }
    }
}