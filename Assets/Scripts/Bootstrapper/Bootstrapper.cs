using System.IO;
using GameMainScene;
using MainMenuScene;
using Services.GlobalAnimation;
using Services.SaveLoadService;
using Services.SceneControlService;
using UnityEngine;

namespace Bootstrapper
{
    public class Bootstrapper : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private GameSceneController _gameSceneController;
        [SerializeField] private MainMenuController _mainMenuSceneController;
        [SerializeField] private Transform _sceneContainer;
        [Header("Animator")]
        [SerializeField] private Animator _globalAnimator;
        
        private void Awake()
        {
            InitServices();
        }

        private void InitServices()
        {
            InitFileLoadService();
            InitSceneControlService();
            InitGlobalAnimationService();
        }

        private void InitFileLoadService()
        {
            var levelLoader = new JsonLevelDataRepository(); 
            
            var obj = new GameObject("SaveLoadService");
            var service = obj.AddComponent<SaveLoadService>();
            service.Init(levelLoader);
            DontDestroyOnLoad(obj);
        }
        
        private void InitSceneControlService()
        {
            var obj = new GameObject("SceneControlService");
            var service = obj.AddComponent<SceneControlService>();
            service.Init(_sceneContainer, _gameSceneController,_mainMenuSceneController);
            DontDestroyOnLoad(obj);
        }
        
        private void InitGlobalAnimationService()
        {
            var obj = new GameObject("GlobalAnimationService");
            var service = obj.AddComponent<GlobalAnimationService>();
            service.Init(_globalAnimator);
            DontDestroyOnLoad(obj);
        }
    }
}
