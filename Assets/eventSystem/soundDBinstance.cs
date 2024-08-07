using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rm2.userDataBase;

namespace rm2.eventSystem
{
    public class soundDBinstance : MonoBehaviour
    {
        public static soundDBinstance instance;

        [SerializeField]
        soundList[] soundLists;

        public List<audioData> audioDatas = new List<audioData>();

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        void initializeDatas(soundList[] datas)
        {
            foreach (var data in datas)
            {
                audioDatas.AddRange(data.audioClips);
            }
        }

        void Start()
        {
            initializeDatas(soundLists);
        }

        public AudioClip getClip(string identifier)
        {
            foreach (var a in audioDatas)
            {
                if (a.identifier == identifier)
                {
                    return a.clip;
                }
            }

            Debug.LogWarning($"identifier \"{identifier}\" is invalid");
            return null;
        }

        public AudioClip getClip(int index)
        {
            if (index < audioDatas.Count && -1 < index)
            {
                return audioDatas[index].clip;
            }

            Debug.LogWarning($"index \"{index}\" is invalid");
            return null;
        }
    }
}
