using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class dummy : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            isDone = true;
            yield return null;
        }
    }
}
