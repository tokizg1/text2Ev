using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class instantText : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string body = args[0];
            int fontSize = int.Parse(args[1]) * 2;
            Vector2 position = parseVect.str2Vec2(args[2]) * 2f;
            string identfier = args[3];

            instantTextManager.instance.generateNewText(body, fontSize, position, identfier);

            yield return null;
            isDone = true;
        }
    }

    public class hideInstantText : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string identfier = args[0];

            instantTextManager.instance.DestroyText(identfier);

            yield return null;
            isDone = true;
        }
    }
}
