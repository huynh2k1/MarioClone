using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HomeManager : MonoBehaviour
{
    public static HomeManager instance;
    public Dialog shopDialog;
    public Text coinText;
    public int coinSum;


    private Dialog _curDialog;
    public Dialog curDialog { get => _curDialog; set => _curDialog = value; }



    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        coinSum = PlayerPrefs.GetInt("Coin");
        CoinUpdate();
    }

    public void SettingButton()
    {

    }
    public void ShopButton()
    {
        if(shopDialog)
        {
            shopDialog.Show(true);
            curDialog = shopDialog;
        }
    }
    public void CloseButton()
    {
        if(curDialog)
        {
            curDialog.Show(false);
        }
    }
    public void PlayButton()
    {
       
    }
    public void CoinUpdate()
    {
        PlayerPrefs.SetInt("Coin", coinSum);
        coinText.text = coinSum.ToString();
    }
}
