using System.Collections;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Animator _animator;
    SpriteRenderer _spriteRenderer;
    Rigidbody2D _rb2D;
    public GameObject firePoint;
    public Vector3 moveInput;

    public float speed;
    public float jumpForce;
    public float horizontalSpeed;
    public float timeFire;
    private float _timeDelay;

    private bool moveRight;
    private bool moveLeft;
    private bool moveUp;
    private bool isGround;
    public bool isShoot;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _timeDelay = 0;
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        moveLeft = false;
        moveRight = false;
        moveUp = false;
        isGround = false;
        isShoot = false;
    }

    private void Update()
    {
        _timeDelay -= Time.deltaTime;
        if (_timeDelay <= 0)
        {
            if (isShoot == true)
            {
                Fire();
                _timeDelay = timeFire;
                isShoot = false;
            }
        }
        Move();
    }
    private void FixedUpdate()
    {
        Jump();
        transform.Translate(Vector2.right * speed * horizontalSpeed * Time.deltaTime, Space.Self);
        
        //Fire();
    }

    private void Move()
    {
        if (moveLeft)
        {
            //if (isGround == false)
            //{
            //    _animator.SetBool("Jumping", true);
            //    horizontalSpeed = -1;
            //    _spriteRenderer.flipX = true;
            //}
            //else
            //{
            //    _animator.SetBool("Jumping", false);
            //    horizontalSpeed = -1;
            //    _spriteRenderer.flipX = true;
            //    _animator.SetFloat("Speed", 1);
            //}
            horizontalSpeed = -1;
            _spriteRenderer.flipX = true;
            _animator.SetFloat("Speed", 1);
        }
        else if (moveRight)
        {
            //if (isGround == false)
            //{
            //    _animator.SetBool("Jumping", true);
            //    horizontalSpeed = 1;
            //    _spriteRenderer.flipX = false ;
            //}
            //else
            //{
            //    _animator.SetBool("Jumping", false);
            //    horizontalSpeed = 1;
            //    _spriteRenderer.flipX = false;
            //    _animator.SetFloat("Speed", 1);
            //}
            horizontalSpeed = 1;
            _spriteRenderer.flipX = false;
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            //if(isGround == false)
            //{
            //    _animator.SetBool("Jumping", true);
            //    horizontalSpeed = 0;
            //    _animator.SetFloat("Speed", 0);
            //}
            //else
            //{
            //    _animator.SetBool("Jumping", false);
            //    horizontalSpeed = 0;
            //    _animator.SetFloat("Speed", 0);
            //}
            horizontalSpeed = 0;
            _animator.SetFloat("Speed", 0);
        }
    }
    private void Jump()
    {
        //Nếu click button Jump và đang ở dưới đất là đúng 
        if (moveUp == true && isGround == true)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpForce);
        }
        //Nếu đang ở dưới đất => Jump action = false
        if (isGround)
        {
            _animator.SetBool("Jumping", false);
        }
        if (moveUp && isGround)
        {
            _animator.SetBool("Jumping", true);
        }
    }
    private void Fire()
    {

        GameObject _kunai = KunaiPooling.Instance.GetPooledKunai();
        if (_kunai != null)
        {
            _kunai.transform.position = transform.position;
            _kunai.SetActive(true);
            _kunai.GetComponent<Kunai>().Init((_spriteRenderer.flipX == true) ? -1 : 1);
        }

    }
    public void ClickLeftBtn()
    {
        moveLeft = true;
    }
    public void UnClickLeftBtn()
    {
        moveLeft = false;
    }
    public void ClickRightBtn()
    {
        moveRight = true;
    }
    public void UnClickRightBtn()
    {
        moveRight = false;
    }
    public void ClickJump()
    {
        Debug.Log("Da cham dat");
        moveUp = true;
    }
    public void UnClickJump()
    {
        moveUp = false;
    }
    public void ClickFire()
    {
        isShoot = true;
    }
    public void UnClickFire()
    {
        isShoot = false;
    }

    private void BlendAnim()
    {
        float _speed = speed;
        if (moveInput == Vector3.zero)
        {
            _speed = 0;
        }
        _animator.SetFloat("Speed", _speed);

    }
    public void PlayerDie()
    {
        Destroy(gameObject);
        //UIManager.Instance.GameLose();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Đang dưới mặt đất");
            isGround = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Đang nhảy");
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Win"))
        {
            Debug.Log("win");
            //UIManager.Instance.GameWin();
        }
    }
}
