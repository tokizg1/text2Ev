using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.userDataBase
{
    [CreateAssetMenu(fileName = "Data", menuName = "rm2/イベント用キャラクターデータ")]
    public class talkCharaDataBase : ScriptableObject
    {
        public List<talkCharaData> talkCharaDatas = new List<talkCharaData>();
    }

    [System.Serializable]
    public class talkCharaData
    {
        public string identifier = "";
        public List<Sprite> expressionSprites = new List<Sprite>();
        public List<Sprite> expressionSpritesAlter = new List<Sprite>();

        /*
        public Sprite getSprite(string identifier)
        {
            Debug.Log("searching sprite: " + identifier);
            Debug.Log("searching in: " + expressionSprites);

            Sprite ret = null;

            foreach (var e in expressionSprites)
            {
                Debug.Log("identifier: " + e.identifier);
                if (e.identifier == identifier)
                {
                    Debug.Log("found sprite: " + e.sprite);
                    ret = e.sprite;
                }
            }

            if (ret == null)
            {
                Debug.LogWarning($"identifier \"{identifier}\" is invalid");
            
                return null;
            }
            return ret;
        }
        */
    }

    [System.Serializable]
    public class expressionSprite
    {
        public string identifier = "";
        public Sprite sprite;
    }
}
