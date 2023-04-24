using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref
{
    public static int CoinNumber
    {
        get => PlayerPrefs.GetInt(Const.COIN, 0);
        set => PlayerPrefs.SetInt(Const.COIN, value);
    }
    public static int HighScore
    {
        get => PlayerPrefs.GetInt(Const.HIGHSCORE, 0);
        set => PlayerPrefs.SetInt(Const.HIGHSCORE, value);
    }

    public static int levelLoading
    {
        get => PlayerPrefs.GetInt(Const.LEVEL, 0);
        set => PlayerPrefs.SetInt(Const.LEVEL, value);
    }
    public static int selectingPlayer
    {
        get => PlayerPrefs.GetInt(Const.SELECTED_PLAYER, 0);
        set => PlayerPrefs.SetInt(Const.SELECTED_PLAYER, value);
    }
}
