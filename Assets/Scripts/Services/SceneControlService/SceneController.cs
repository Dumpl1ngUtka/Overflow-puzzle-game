using UnityEngine;

namespace Services.SceneControlService
{
    public abstract class SceneController : MonoBehaviour
    {
        public void Init()
        {
            OnEnter();
        }
        
        public void Destroy()
        {
            OnExit();
            Destroy(gameObject);
        }
        
        protected abstract void OnEnter();
        protected abstract void OnExit();
    }
}