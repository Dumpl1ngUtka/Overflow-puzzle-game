using GameMainScene;
using Services.SceneControlService;
using UnityEngine;

namespace MainMenuScene
{
    [RequireComponent(typeof(MainMenuView))]
    public class MainMenuController : SceneController
    {
        private MainMenuView _view;
        private MainMenuModel _model;
        
        protected override void OnEnter()
        {
            _model = new MainMenuModel();
            _view = GetComponent<MainMenuView>();
        }

        public void OnPlayButtonClicked() => _model.Play();
        
        public void OnExitButtonClicked() => _model.Exit();
        
        public void OnSettingsButtonClicked() => _model.Settings();

        protected override void OnExit()
        {
        }
    }
}