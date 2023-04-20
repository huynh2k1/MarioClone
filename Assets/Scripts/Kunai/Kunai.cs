using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;
    // private Vector3 _direction;
    public int dir;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void Init(int Dir)
    {
        dir = Dir;
    }
    private void Move()
    {
        // _rb.AddForce(_direction * moveSpeed, ForceMode2D.Impulse);
        //_rb.velocity = _direction * moveSpeed * Time.deltaTime;
        transform.Translate(dir * Vector2.right * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
