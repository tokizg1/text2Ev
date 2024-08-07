using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using rm2.userDataBase;

namespace rm2.eventSystem
{
    public class talkCharaDBinstance : MonoBehaviour
    {
        public static talkCharaDBinstance instance;

        [SerializeField]
        talkCharaDataBase[] talkCharaDBs;

        public List<talkCharaData> talkCharaDatas = new List<talkCharaData>();

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

        void initializeDatas(talkCharaDataBase[] datas)
        {
            foreach (var data in datas)
            {
                talkCharaDatas.AddRange(data.talkCharaDatas);
            }
        }

        void Start()
        {
            initializeDatas(talkCharaDBs);
        }

        public talkCharaData getChara(string identifier)
        {
            Debug.Log("searching chara: " + identifier);
            return talkCharaDatas.Find(t => t.identifier == identifier);
        }

        /// <summary>
        /// keyを指定してSpriteを取得する
        /// </summary>
        /// <param name="key">取得したいSpriteのIdentifier( charaIdentifier.expressionIdentifer )</param>
        /// <returns>取得したSprite. 取得できなかった場合はnull.</returns>
        public Sprite getSprite(string charaIdentifier, int expressionIdentifier, bool isAlter)
        {
            talkCharaData chara = this.getChara(charaIdentifier);
            if (chara == null)
            {
                Debug.LogWarning($"expressionSprite \"{charaIdentifier}\" not found");
                return null;
            }

            //Sprite retSprite = chara.getSprite(expressionIdentifier);

            Sprite retSprite = isAlter
                ? chara.expressionSpritesAlter[expressionIdentifier]
                : chara.expressionSprites[expressionIdentifier];

            if (retSprite == null)
            {
                Debug.LogWarning($"sprite \"{expressionIdentifier}\" not found");
                return null;
            }

            return retSprite;
        }
    }
}
