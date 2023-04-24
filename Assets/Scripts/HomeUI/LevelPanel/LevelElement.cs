using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelElement : MonoBehaviour
{
    public Text idLevetTxt;
    public Button buttonLevel;
    public void Awake()
    {
        buttonLevel.onClick.AddListener(LoadLevel);
    }

    public void Init(int IdLvel)
    {
        idLevetTxt.text = IdLvel.ToString();
        buttonLevel  = gameObject.GetComponent<Button>();
    }    
    public void LoadLevel()
    {
        Pref.levelLoading =  int.Parse(idLevetTxt.text);
        SceneManager.LoadScene("GamePlay");

    }    
}
