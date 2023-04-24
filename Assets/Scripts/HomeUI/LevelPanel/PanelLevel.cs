using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelLevel : MonoBehaviour
{
    public GameObject backGround;
    public GameObject main;

    public List<LevelElement>  listLevelElements;

    public void Start()
    {
        InitAllLevel();
    }
    public void InitAllLevel()
    {
        for(int i = 0; i < listLevelElements.Count; i++) { 
        
            listLevelElements[i].Init(i+1);
        }
    }
    

}
