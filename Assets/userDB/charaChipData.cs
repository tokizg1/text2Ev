using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rm2.userDataBase
{
    [CreateAssetMenu(fileName = "Data", menuName = "rm2/キャラチップデータ")]
    public class charaChipData : ScriptableObject
    {
        public Sprite[] sprites;
    }
}
