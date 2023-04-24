using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y < 0)
        {
            StartCoroutine(SetAnimDie());
            GameManager.Instance.score += 100;
            GameManager.Instance.StatUpdate();
        }
    }
    IEnumerator SetAnimDie()
    {
        _animator.SetBool("isDie", true);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
