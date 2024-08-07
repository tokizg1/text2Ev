using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace rm2.eventSystem
{
    public class standImagesController : MonoBehaviour
    {
        public static standImagesController instance;

        public List<Transform> standImages = new List<Transform>();

        List<string> keys = new List<string>();
        List<Animator> animators = new List<Animator>();
        List<Image> renderers = new List<Image>();

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            foreach (var standImage in standImages)
            {
                animators.Add(standImage.GetComponent<Animator>());
                renderers.Add(standImage.GetComponent<Image>());
                keys.Add(standImage.name);
            }

            foreach (var render in renderers)
            {
                render.enabled = false;
            }
        }

        public void setSprite(string imageName, Sprite sprite)
        {
            var index = keys.IndexOf(imageName);
            if (index == -1)
            {
                Debug.LogWarning($"image name \"{imageName}\" is invalid");
                return;
            }
            renderers[index].sprite = sprite;
        }

        public void setVisible(string imageName, bool visible)
        {
            var index = keys.IndexOf(imageName);
            if (index == -1)
            {
                Debug.LogWarning($"image name \"{imageName}\" is invalid");
                return;
            }
            renderers[index].enabled = visible;
        }

        public void setTrigger(string imageName, string trigger)
        {
            var index = keys.IndexOf(imageName);
            if (index == -1)
            {
                Debug.LogWarning($"image name \"{imageName}\" is invalid");
                return;
            }
            animators[index].SetTrigger(trigger);
        }
    }
}
