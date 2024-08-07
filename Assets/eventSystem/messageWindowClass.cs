using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rm2.eventSystem
{
    public class messageWindowClass : MonoBehaviour
    {
        public static messageWindowClass instance;

        Animator animator;

        [SerializeField]
        TMP_Text nameText;

        [SerializeField]
        TMP_Text bodyText;

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
            animator = GetComponent<Animator>();
        }

        public IEnumerator showText(
            string name,
            string text,
            float speed,
            bool hideWindow,
            bool isAuto
        )
        {
            nameText.text = name;

            string curBlock = text.Replace(";", "\n").Replace("_", " ");
            //curBlock = Epm.repValable(curBlock);
            int charNum = 0;
            bodyText.text = curBlock;
            animator.SetBool("enable", true);
            while (charNum < curBlock.Length + 1)
            {
                /*
                if (eventManager.instance.skip)
                {
                    charNum = curBlock.Length + 1;
                }
                else
                {*/
                charNum++;
                //}
                bodyText.maxVisibleCharacters = charNum;
                eventManager.instance.soundEffectSource.PlayOneShot(
                    soundDBinstance.instance.getClip(0)
                );
                if (Input.GetKey(KeyCode.P))
                {
                    break;
                }
                yield return new WaitForSeconds(
                    0.025f / speed /* / eventManager.instance.textSpeed */
                );
            }

            if (!isAuto)
            {
                yield return new WaitUntil(
                    () => Input.GetButtonDown("Submit") || Input.GetKey(KeyCode.P)
                );
            }

            if (hideWindow || Input.GetKey(KeyCode.P))
            {
                animator.SetBool("enable", false);
            }
            yield return null;
        }
    }
}
