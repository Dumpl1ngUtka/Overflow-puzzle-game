using UnityEngine;
using UnityEngine.UI;

namespace GameMainScene.Flask
{
    public class FlaskColor : MonoBehaviour
    {
        private Image _image;

        public void Init()
        {
            _image = GetComponent<Image>();
        }
        
        public void SetColor(Color color)
        {
            _image.color = color; 
            //play enter animation 
        }

        public void ResetColor()
        {
            _image.color = Color.clear; 
            //play exit anim
        }
    }
}