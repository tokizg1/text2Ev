using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class instantTextManager : MonoBehaviour
{
    public static instantTextManager instance;

    [SerializeField]
    GameObject textPrefab;

    [SerializeField]
    Dictionary<string, TMP_Text> textList = new Dictionary<string, TMP_Text>();

    public void Awake()
    {
        instance = this;
    }

    public void generateNewText(string body, int fontSize, Vector2 position, string identfier)
    {
        GameObject textObj = Instantiate(textPrefab, Vector3.zero, Quaternion.identity);
        textObj.transform.SetParent(transform);
        textObj.GetComponent<RectTransform>().anchoredPosition = position;
        textObj.GetComponent<RectTransform>().localScale = Vector3.one;

        textObj.GetComponent<TMP_Text>().text = body.Replace(";", "\n").Replace("_", " ");
        ;
        textObj.GetComponent<TMP_Text>().fontSize = fontSize;
        textList.Add(identfier, textObj.GetComponent<TMP_Text>());
    }

    public void DestroyText(string identfier)
    {
        Destroy(textList[identfier].gameObject);
        textList.Remove(identfier);
    }
}
