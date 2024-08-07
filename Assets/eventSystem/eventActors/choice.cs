using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace rm2.eventSystem
{
    public class choice : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string[] choices = args;
            int result = 0;

            evman.jump(evman.currentEventIndex + 1 + result);
            choiceWindow.instance.Initialize(choices);
            yield return choiceWindow.instance.makeChoice();
            result = choiceWindow.instance.result;
            evman.jump(evman.currentEventIndex + result - 1);
            yield return null;
            isDone = true;
        }
    }
}
