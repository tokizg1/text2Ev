using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class textWindow : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string chara = args[0];
            string text = args[1];

            bool hideWindow = false;
            if (args.Length > 2)
                hideWindow = args[2] == "1";

            float speed = 1.0f;
            if (args.Length > 3)
                speed = float.Parse(args[3]);

            bool isAuto = false;
            if (args.Length > 4)
                isAuto = args[4] == "1";

            yield return messageWindowClass.instance.showText(
                chara,
                text,
                speed,
                hideWindow,
                isAuto
            );
            isDone = true;
        }
    }
}
