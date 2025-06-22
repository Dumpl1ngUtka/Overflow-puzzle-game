using GameMainScene;
using MainMenuScene;
using UnityEngine;

namespace Services.SceneControlService
{
    public class SceneControlService : MonoBehaviour
    {
        private static SceneControlService _instance;
        
        private SceneController _currentSceneController;
        private Transform _container;

        public static SceneControlService Instance => 
            _instance ?? FindAnyObjectByType(typeof(SceneControlService)) as SceneControlService;

        public SceneController GameControllerPrefab; 
        public MainMenuController MainMenuPrefab; 
        
        public void Init(Transform container, GameSceneController gameSceneControllerPrefab, MainMenuController mainMenuPrefab)
        {
            GameControllerPrefab = gameSceneControllerPrefab;
            MainMenuPrefab = mainMenuPrefab;
            _container = container;
        }

        private void Start()
        {
            ChangeScene(MainMenuPrefab);
        }

        public void ChangeScene(SceneController sceneControllerPrefab)
        {
            _currentSceneController?.Destroy();
            _currentSceneController = Instantiate(sceneControllerPrefab, _container);
            _currentSceneController.transform.SetAsFirstSibling();
            _currentSceneController.Init();
        }
    }
}