using System.Collections.Generic;
using Services.GlobalAnimation;
using UnityEditor.Animations;
using UnityEngine;

namespace CustomAnimator
{
    [RequireComponent(typeof(Animator))]
    public class CustomAnimator : MonoBehaviour
    {
        [SerializeField] private float _animationSpeed = 1f;
        private Animator _animator;
        private readonly Queue<AnimationClip> _animationQueue = new Queue<AnimationClip>();
        private bool _isPlaying;
        
        public Animator Animator => _animator == null ? _animator = GetComponent<Animator>() : _animator;
        
        public void PlayAnimation(AnimationClip clip)
        {
            _animationQueue.Enqueue(clip);  

            if (!_isPlaying) 
                PlayNextAnimation();
        }

        public void PlayRandomAnimation(string animationsPath)
        {
            PlayAnimation(GetRandomAnimation(animationsPath));
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
            state.speed = _animationSpeed;

            Animator.runtimeAnimatorController = controller;
            
            StartCoroutine(WaitForAnimationEnd(nextClip.length / _animationSpeed));
        }

        private System.Collections.IEnumerator WaitForAnimationEnd(float animationLength)
        {
            yield return new WaitForSeconds(animationLength);
            PlayNextAnimation();
        }

        public void OnDestroy()
        {
            //StopAllCoroutines();
        }
        
        private AnimationClip GetRandomAnimation(string path)
        {
            var clips = Resources.LoadAll<AnimationClip>(path);
            return clips[Random.Range(0, clips.Length)];
        }
    }
}