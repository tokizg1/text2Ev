using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    [System.Serializable]
    public class eventClass
    {
        public eventActor actor;
        public string actorType;
        public string[] args;

        public eventClass[] includance;

        public eventClass(eventActor actor, string[] args)
        {
            this.actor = actor;
            this.actorType = actor.GetType().Name;
            this.args = args;
        }

        public eventClass(string[] args, eventClass[] includance)
        {
            this.actor = new dummy();
            this.actorType = "eventBlock";
            this.args = args;
            this.includance = includance;
        }
    }
}
