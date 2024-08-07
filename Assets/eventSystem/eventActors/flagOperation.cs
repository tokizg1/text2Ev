using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class flagOperation : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string flagName = args[0];
            string operation = args[1];
            int value = int.Parse(args[2]);

            switch (operation)
            {
                case "=":
                    commonFlag.instance.setFlag(flagName, value);
                    break;
                case "+=":
                    commonFlag.instance.setFlag(
                        flagName,
                        commonFlag.instance.getFlag(flagName) + value
                    );
                    break;
                case "-=":
                    commonFlag.instance.setFlag(
                        flagName,
                        commonFlag.instance.getFlag(flagName) - value
                    );
                    break;
                default:
                    Debug.LogWarning("Invalid operation: " + operation);
                    break;
            }
            isDone = true;
            yield return null;
        }
    }
}
