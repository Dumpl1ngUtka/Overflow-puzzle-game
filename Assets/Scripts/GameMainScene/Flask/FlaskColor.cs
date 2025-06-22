using UnityEngine;
using UnityEngine.UI;

namespace GameMainScene.Flask
{
    public class FlaskColor : MonoBehaviour
    {
        private const string FillAnimationPath = "Animations/Flask/Enter";
        private const string ResetAnimationPath = "Animations/Flask/Exit";
        private Image _image;
        private CustomAnimator.CustomAnimator _animator;

        public void Init()
        {
            _image = GetComponent<Image>();
            _animator = GetComponent<CustomAnimator.CustomAnimator>();
        }
        
        public void SetColor(Color color)
        {
            _image.color = color;
            _animator.PlayRandomAnimation(FillAnimationPath);
        }

        public void ResetColor()
        {
            _animator.PlayRandomAnimation(ResetAnimationPath);
        }
    }
}