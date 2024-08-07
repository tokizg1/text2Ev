using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class indexJump : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            evman.jump(int.Parse(args[0]));
            isDone = true;
            yield return null;
        }
    }
}
