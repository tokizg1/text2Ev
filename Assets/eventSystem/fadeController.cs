using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace rm2.eventSystem
{
    [RequireComponent(typeof(Animator))]
    public class fadeController : MonoBehaviour
    {
        public static fadeController instance;

        Animator animator;

        [SerializeField]
        float currentFadeValue = 0.0f;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            animator = GetComponent<Animator>();
            animator.SetFloat("fade", currentFadeValue);
        }

        public IEnumerator FadeOut(float duration)
        {
            currentFadeValue = 0.0f;

            while (currentFadeValue < 1.0f)
            {
                currentFadeValue = Mathf.MoveTowards(
                    currentFadeValue,
                    1.0f,
                    Time.deltaTime / duration
                );
                animator.SetFloat("fade", currentFadeValue);
                yield return null;
            }
        }

        public IEnumerator FadeIn(float duration)
        {
            currentFadeValue = 1.0f;

            while (currentFadeValue > 0.0f)
            {
                currentFadeValue = Mathf.MoveTowards(
                    currentFadeValue,
                    0.0f,
                    Time.deltaTime / duration
                );
                animator.SetFloat("fade", currentFadeValue);
                yield return null;
            }
        }
    }
}
