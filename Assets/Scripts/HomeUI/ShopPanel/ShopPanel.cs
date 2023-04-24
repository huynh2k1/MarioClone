using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour
{
    public List<ShopElement> listShopElements;
    public GameObject shopPanel;
    public void InitAllPlayer()
    {
        for(int i = 0; i < listShopElements.Count; i++)
        {
            listShopElements[i].Init(i + 1);
        }
    }
   
}
