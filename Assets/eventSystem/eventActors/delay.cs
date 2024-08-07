using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class delay : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            float delayTime = 0.0f;
            delayTime = float.Parse(args[0]);

            Debug.Log("delay: " + delayTime + " seconds");
            yield return new WaitForSeconds(delayTime);
            isDone = true;
            yield return null;
        }
    }
}
