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

    private void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentPoint = pointA.transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
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
}
