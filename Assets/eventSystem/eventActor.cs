using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public abstract class eventActor
    {
        public bool isDone = false;
        public abstract IEnumerator execute(eventManager evman, string[] args);
    }
}
