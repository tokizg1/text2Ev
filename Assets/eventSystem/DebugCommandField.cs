using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace rm2.eventSystem
{
    [RequireComponent(typeof(TMP_InputField))]
    public class DebugCommandField : MonoBehaviour
    {
        TMP_InputField inputField;

        void Start()
        {
            inputField = GetComponent<TMP_InputField>();
        }

        public void execute()
        {
            eventClass[] command = eventParser.parseEvent(inputField.text);
            if (command == null)
            {
                return;
            }
            StartCoroutine(eventManager.instance.executeEvent(command));
        }
    }
}
