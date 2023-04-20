using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref
{
    public static int CoinNumber
    {
        get => PlayerPrefs.GetInt("Coin", 0);
        set => PlayerPrefs.SetInt("Coin", value);
    }
    public static int HighScore
    {
        get => PlayerPrefs.GetInt("HighScore", 0);
        set => PlayerPrefs.SetInt("HighScore", value);
    }

}
