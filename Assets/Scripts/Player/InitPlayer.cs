using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayer : MonoBehaviour
{
    public Transform player; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject _player = SelectCharacter.selectedPlayer;
        Instantiate(_player, player);
    }
}
