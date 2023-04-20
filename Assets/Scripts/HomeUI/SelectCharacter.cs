using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectCharacter : MonoBehaviour
{
    private int index;
    public GameObject[] characters;
    public GameObject[] characterPrefabs;

    public Text nameCharacter;
    public static GameObject selectedPlayer;


    private void Start()
    {
        index = 0;
        SelectPlayer();
    }

    public void NextButton()
    {
        if(index < characters.Length - 1)
        {
            index++;
        }
        SelectPlayer();
    }
    public void PreButton()
    {
        if(index > 0)
        {
            index--;
        }
        SelectPlayer();
    }
    
    private void SelectPlayer()
    {
        for(int i = 0; i < characters.Length; i++)
        {
            if(i == index)
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.white;
                characters[i].GetComponent<Animator>().enabled = true;
                selectedPlayer = characterPrefabs[i];
                nameCharacter.text = characterPrefabs[i].name;
            }
            else
            {
                characters[i].GetComponent<SpriteRenderer>().color = Color.black;
                characters[i].GetComponent<Animator>().enabled = false;
            }
        }
    }
}
