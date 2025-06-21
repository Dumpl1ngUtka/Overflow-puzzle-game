using GameMainScene;
using UnityEngine;

namespace Services.SceneControlService
{
    public class SceneControlService : MonoBehaviour
    {
        private static SceneControlService _instance;
        
        private SceneController _currentSceneController;
        private Canvas _canvas;

        public static SceneControlService Instance => 
            _instance ?? FindAnyObjectByType(typeof(SceneControlService)) as SceneControlService;

        public SceneController GameControllerPrefab; 
        
        public void Init(Canvas canvas, GameSceneController gameSceneControllerPrefab)
        {
            GameControllerPrefab = gameSceneControllerPrefab;
            _canvas = canvas;
            
            ChangeScene(GameControllerPrefab);
        }

        public void ChangeScene(SceneController sceneControllerPrefab)
        {
            //play transition animation
            _currentSceneController?.Destroy();
            _currentSceneController = Instantiate(sceneControllerPrefab, _canvas.transform);
            _currentSceneController.Init();
        }
    }
}