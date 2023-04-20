using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && (collision.contacts[0].normal.x < 0 || collision.contacts[0].normal.x > 0))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            GameManager.Instance.coin += 10;
            GameManager.Instance.score += 10;
            GameManager.Instance.StatUpdate();

            HomeManager.instance.coinSum += 10;
            HomeManager.instance.CoinUpdate();


        }
    }
}
