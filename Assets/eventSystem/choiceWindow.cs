using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;

namespace rm2.eventSystem
{
    public class choiceWindow : MonoBehaviour
    {
        public static choiceWindow instance;

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
            gameObject.SetActive(false);
            rectTransform = GetComponent<RectTransform>();
        }

        Animator animator;

        [SerializeField]
        int outerMargin = 16;

        [SerializeField]
        int choiceMargin = 16;

        [SerializeField]
        int fontSize = 64;

        [SerializeField]
        TMP_Text[] choiceText;

        [SerializeField]
        GameObject choicePrefab;

        public int result = 0;

        RectTransform rectTransform;

        public void Initialize(string[] choices)
        {
            gameObject.SetActive(true);
            choiceText = new TMP_Text[choices.Length];
            for (int i = 0; i < choices.Length; i++)
            {
                var choice = Instantiate(choicePrefab, transform).GetComponent<RectTransform>();
                choice.transform.SetParent(transform);
                choice.anchorMin = new Vector2(0, 1);
                choice.anchorMax = new Vector2(1, 1);
                choice.sizeDelta = new Vector2(0, fontSize);
                choice.anchoredPosition = new Vector3(
                    fontSize,
                    -outerMargin - choiceMargin * i - fontSize * (i + 1),
                    0
                );
                choiceText[i] = choice.GetComponent<TMP_Text>();
                choiceText[i].text = choices[i];
            }

            rectTransform.anchorMax = new Vector2(1, 0.5f);
            rectTransform.anchorMin = new Vector2(1, 0.5f);
            rectTransform.pivot = new Vector2(0.5f, 0);
            rectTransform.sizeDelta = new Vector2(
                640,
                2 * outerMargin + (choices.Length + 1) * fontSize + choices.Length * choiceMargin
            );
            rectTransform.anchoredPosition = new Vector2(-640, -320);
        }

        void destruct()
        {
            gameObject.SetActive(false);
        }

        public IEnumerator makeChoice()
        {
            result = 0;
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    result = (result + choiceText.Length - 1) % choiceText.Length;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    result = (result + 1) % choiceText.Length;
                }
                else if (Input.GetKeyDown(KeyCode.Return))
                {
                    break;
                }

                for (int i = 0; i < choiceText.Length; i++)
                {
                    choiceText[i].color = i == result ? Color.yellow : Color.white;
                }
                yield return null;
            }
            destruct();
        }
    }
}
