using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Services.GlobalAnimation
{
    public class GlobalAnimationService : MonoBehaviour
    {
        private const float AnimationSpeed = 2f;
        
        private Animator _animator;
        private readonly Queue<AnimationClip> _animationQueue = new Queue<AnimationClip>();
        private bool _isPlaying;
        private static GlobalAnimationService _instance;
        
        public static GlobalAnimationService Instance =>  _instance ?? FindAnyObjectByType<GlobalAnimationService>();

        public void Init(Animator animator)
        {
            _animator = animator;
        }

        public float GetSpeed()
        {
            return AnimationSpeed;
        }
        
        public void PlayAnimation(AnimationClip clip)
        {
            _animationQueue.Enqueue(clip);

            if (!_isPlaying) 
                PlayNextAnimation();
        }

        private void PlayNextAnimation()
        {
            if (_animationQueue.Count == 0)
            {
                _isPlaying = false;
                return;
            }

            _isPlaying = true;
            var nextClip = _animationQueue.Dequeue();

            var controller = new AnimatorController();
            controller.AddLayer("Base Layer");
            var state = controller.AddMotion(nextClip, 0);
            state.speed = AnimationSpeed;
            
            _animator.runtimeAnimatorController = controller;
            
            StartCoroutine(WaitForAnimationEnd(nextClip.length/AnimationSpeed));
        }

        private System.Collections.IEnumerator WaitForAnimationEnd(float animationLength)
        {
            yield return new WaitForSeconds(animationLength);
            PlayNextAnimation();
        }

        public void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}