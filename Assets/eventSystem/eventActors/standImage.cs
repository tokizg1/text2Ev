using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class setSI : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string imageIdentifier = args[0];
            string charaIdentiier = args[1];
            int expressionIdentifier = int.Parse(args[2]);
            bool isAlter = bool.Parse(args[3]);

            Sprite sprite = talkCharaDBinstance.instance.getSprite(
                charaIdentiier,
                expressionIdentifier,
                isAlter
            );
            if (sprite != null)
            {
                standImagesController.instance.setSprite(imageIdentifier, sprite);
            }

            isDone = true;
            yield return null;
        }
    }

    public class setSIVisible : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string imageIdentifier = args[0];
            bool visible = bool.Parse(args[1]);

            standImagesController.instance.setVisible(imageIdentifier, visible);

            isDone = true;
            yield return null;
        }
    }

    public class setSITrigger : eventActor
    {
        public override IEnumerator execute(eventManager evman, string[] args)
        {
            string imageIdentifier = args[0];
            string triggerIdentifier = args[1];

            standImagesController.instance.setTrigger(imageIdentifier, triggerIdentifier);

            isDone = true;
            yield return null;
        }
    }
}
