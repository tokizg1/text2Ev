using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.eventSystem
{
    public class eventManager : MonoBehaviour
    {
        public static eventManager instance;

        public bool executing = false;
        public int currentEventIndex = 0;
        public eventClass[] eventClasses;

        public AudioSource soundEffectSource;
        public AudioSource backgroundMusicSource;

        public GameObject instEvman;

        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public IEnumerator executeEvent(eventClass[] classes)
        {
            eventClasses = classes;
            executing = true;
            yield return runEvent(eventClasses[0]);
            yield return null;
        }

        IEnumerator runEvent(eventClass evClss)
        {
            var actor = evClss.actor;
            var args = evClss.args;

            if (!actor.isDone)
            {
                currentEventIndex++;
                Debug.Log("Executing actor: " + actor);
                StartCoroutine(actor.execute(this, args));
                yield return new WaitUntil(() => actor.isDone);
            }
            if (currentEventIndex < eventClasses.Length)
            {
                if (eventClasses[currentEventIndex].actorType == "eventBlock")
                {
                    var instantEventManager = GameObject
                        .Instantiate(instEvman)
                        .GetComponent<instantEventManager>();
                    yield return instantEventManager.executeEvent(
                        eventClasses[currentEventIndex].includance
                    );
                    yield return new WaitUntil(() => instantEventManager.executing == false);
                    Destroy(instantEventManager.gameObject);
                    Debug.Log("Block executed");
                }
                StartCoroutine(runEvent(eventClasses[currentEventIndex]));
            }
            else
            {
                Debug.Log("All events done!");
                currentEventIndex = 0;
                executing = false;
            }

            yield return null;
        }

        public void jump(int index)
        {
            if (index < eventClasses.Length && index >= 0)
                currentEventIndex = index;
            else
                Debug.LogWarning("indexJump: index out of range");
        }
    }
}
