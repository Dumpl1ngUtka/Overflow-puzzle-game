using System;
using GameMainScene;
using Services.SaveLoadService;
using Services.SceneControlService;
using UnityEngine;

namespace Bootstrapper
{
    public class Bootstrapper : MonoBehaviour
    {
        private const string SaveFilePath = "";
        
        [SerializeField] private GameSceneController _gameSceneController;
        [SerializeField] private Canvas _canvas;
        
        private void Awake()
        {
            InitServices();
        }

        private void InitServices()
        {
            InitFileLoadService();
            InitSceneControlService();
        }

        private void InitFileLoadService()
        {
            var levelLoader = new JsonLevelDataRepository(); 
            
            var obj = new GameObject("SaveLoadService");
            var service = obj.AddComponent<SaveLoadService>();
            service.Init(levelLoader, SaveFilePath);
            DontDestroyOnLoad(obj);
        }
        
        private void InitSceneControlService()
        {
            var obj = new GameObject("SceneControlService");
            var service = obj.AddComponent<SceneControlService>();
            service.Init(_canvas, _gameSceneController);
            DontDestroyOnLoad(obj);
        }
    }
}
