using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class parseVect
{
    public static Vector2 str2Vec2(string str)
    {
        //str example : "(50.0,50.0)"
        str = str.Replace(" ", "")
            .Replace("\t", "")
            .Replace("\n", "")
            .Replace("(", "")
            .Replace(")", "");
        string[] cor = str.Split(',');
        float x = float.Parse(cor[0]);
        float y = float.Parse(cor[1]);
        Vector2 ret = new Vector2(x, y);
        return ret;
    }
}
