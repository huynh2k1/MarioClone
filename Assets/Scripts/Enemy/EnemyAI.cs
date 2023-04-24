using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb2D;
    Transform _currentPoint;
    public float speed;
    Animator _animator;
    public bool isFlip;
    CapsuleCollider2D _capsuleCollider;

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        _currentPoint = pointA.transform;
    }

    private void Update()
    {
        MoveByPoint();
    }
    private void MoveByPoint()
    {
        Vector2 point = _currentPoint.position - transform.position;
        if (_currentPoint == pointB.transform)
        {
            _rb2D.velocity = new Vector2(speed, 0);
        }
        else
        {
            _rb2D.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == pointB.transform)
        {
            Flip();
            _currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == pointA.transform)
        {
            Flip();
            _currentPoint = pointB.transform;
        }
    }
    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts[0].normal.y < 0)
        {
            StartCoroutine(SetAnimDie());
            GameManager.Instance.score += 100;
            GameManager.Instance.StatUpdate();
        }
    }
    
    IEnumerator SetAnimDie()
    {
        speed = 0;
        _rb2D.bodyType = RigidbodyType2D.Kinematic;
        _animator.SetBool("isDie", true);
        _capsuleCollider.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
