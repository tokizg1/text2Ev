using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class Fade : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string mode = args[0];

            if (mode.Contains("In"))
                yield return fadeController.instance.FadeIn(0.5f);
            else if (mode.Contains("Out"))
                yield return fadeController.instance.FadeOut(0.5f);
            else
                Debug.LogWarning("Invalid mode: " + mode);

            isDone = true;
            yield return null;
        }
    }
}
