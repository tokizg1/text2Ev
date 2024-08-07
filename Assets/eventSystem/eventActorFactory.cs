using UnityEngine;

namespace rm2.eventSystem
{
    public static class eventActorFactory
    {
        public static eventActor str2EA(string str)
        {
            eventActor result = new dummy();

            switch (str)
            {
                case "choice":
                    result = new choice();
                    break;
                case "debugLog":
                    result = new debugLog();
                    break;
                case "delay":
                    result = new delay();
                    break;
                case "ending":
                    result = new ending();
                    break;
                case "textWindow":
                    result = new textWindow();
                    break;
                case "indexJump":
                    result = new indexJump();
                    break;
                case "flagOperation":
                    result = new flagOperation();
                    break;
                case "setSI":
                    result = new setSI();
                    break;
                case "setSIVisible":
                    result = new setSIVisible();
                    break;
                case "setSITrigger":
                    result = new setSITrigger();
                    break;
                case "fade":
                    result = new Fade();
                    break;
                case "waitSubmit":
                    result = new waitSubmit();
                    break;
                case "instantText":
                    result = new instantText();
                    break;
                case "hideInstantText":
                    result = new hideInstantText();
                    break;

                default:
                    Debug.LogWarning("eventActor not found: " + str);
                    break;
            }

            return result;
        }
    }
}
