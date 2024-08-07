using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class waitSubmit : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
            isDone = true;
        }
    }
}
