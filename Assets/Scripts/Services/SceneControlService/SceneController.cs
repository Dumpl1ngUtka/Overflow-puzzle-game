using Services.GlobalAnimation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Services.SceneControlService
{
    public abstract class SceneController : MonoBehaviour
    {
        [Header("Transition Animation Parameters")]
        [SerializeField] private AnimationClip _enterAnimationClip;
        [SerializeField] private AnimationClip _exitAnimationClip;
        
        public void Init()
        {
            var clip = _enterAnimationClip == null? GetRandomTransitionAnimation(true) : _enterAnimationClip;
            GlobalAnimationService.Instance.PlayAnimation(clip);
            OnEnter();
        }

        public void Destroy()
        {
            var service = GlobalAnimationService.Instance;
            var clip = _exitAnimationClip == null? GetRandomTransitionAnimation(false) : _exitAnimationClip;
            service.PlayAnimation(clip);
            OnExit();
            Invoke(nameof(DestroyGameObject), clip.length / service.GetSpeed());
        }
        
        protected abstract void OnEnter();
        protected abstract void OnExit();
        
        private AnimationClip GetRandomTransitionAnimation(bool isEnter)
        {
            var path = "Animations/Transition/" + (isEnter? "Enter/" : "Exit/");
            var clips = Resources.LoadAll<AnimationClip>(path);
            return clips[Random.Range(0, clips.Length)];
        }
        
        private void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}