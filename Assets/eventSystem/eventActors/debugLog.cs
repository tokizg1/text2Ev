using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class debugLog : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            Debug.Log(args[0]);
            isDone = true;
            yield return null;
        }
    }
}
