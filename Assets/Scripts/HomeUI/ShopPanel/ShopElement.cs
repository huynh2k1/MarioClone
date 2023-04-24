using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopElement : MonoBehaviour
{
    public Text namePlayer;
    public Button useButton;
    public Text stateText;
    public Image playerImage;
    public int index;

    private void Awake()
    {
        useButton.onClick.AddListener(LoadPlayer);
    }
    public void Init(int idPlayer)
    {
        //index = idPlayer;
        namePlayer = GetComponent<Text>();
        useButton = GetComponent<Button>();
        playerImage = GetComponent<Image>();
        stateText = GetComponent<Text>();
    }
    public void LoadPlayer()
    {
        Pref.selectingPlayer = index;
    }
}
