using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class commonFlag : MonoBehaviour
    {
        public static commonFlag instance;

        public List<flag> flags = new List<flag>();

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
                Destroy(gameObject);
        }

        public void setFlag(string flagName, int value)
        {
            var targetFlag = flags.Find(f => f.flagName == flagName);
            if (targetFlag == null)
            {
                flags.Add(new flag { flagName = flagName, flagValue = value });
            }
            else
            {
                targetFlag.setFlag(value);
            }
        }

        public int getFlag(string flagName)
        {
            var targetFlag = flags.Find(f => f.flagName == flagName);
            if (targetFlag == null)
            {
                flags.Add(new flag { flagName = flagName, flagValue = 0 });
                return 0;
            }
            else
            {
                return targetFlag.getFlag();
            }
        }
    }
}
