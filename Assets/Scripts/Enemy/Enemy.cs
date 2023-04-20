using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y < 0)
        {
            Destroy(gameObject);
            GameManager.Instance.score += 100;
            GameManager.Instance.StatUpdate();

            
        }
    }
}
