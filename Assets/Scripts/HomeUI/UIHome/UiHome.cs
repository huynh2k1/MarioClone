using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiHome : MonoBehaviour
{
    public static UiHome Instance;

    public Dialog levelPanel;
    public Dialog shopPanel;
    public Dialog homePanel;

    private Dialog _curDialog;
    public Dialog curDialog { get => _curDialog; set => _curDialog = value; }

    public Text coinText;
    public int coinSum;

    public void Awake()
    {
        Instance = this;   
    }
    private void Start()
    {
        OpenHome();
    }
    public void OpenHome()
    {
        if (homePanel)
        {
            homePanel.Show(true);
            curDialog = homePanel;
        }
    }
    public void OpenShop()
    {
        if (shopPanel)
        {
            shopPanel.Show(true);
            curDialog = shopPanel;
        }
    }
    public void OpenLevel()
    {
        if(levelPanel)
        {
            levelPanel.Show(true);
            curDialog = levelPanel;
        }
    }
    public void Close()
    {
        curDialog.Show(false);
    }
    public void UpdateCoin()
    {
        PlayerPrefs.SetInt(Const.COIN, coinSum);
        coinText.text = coinSum.ToString();
    }
}
