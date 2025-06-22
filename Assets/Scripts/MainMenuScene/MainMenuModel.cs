using Services.SceneControlService;
using UnityEngine;

namespace MainMenuScene
{
    public class MainMenuModel
    {
        public void Play()
        {
            var service = SceneControlService.Instance;
            service.ChangeScene(service.GameControllerPrefab);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Settings()
        {
            var service = SceneControlService.Instance;
            service.ChangeScene(service.GameControllerPrefab);        
        }
    }
}