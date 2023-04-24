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
    private bool isGround;
    public bool isShoot;

    public List<GameObject> listPlayerObj;

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
        isGround = false;
        isShoot = false;
        listPlayerObj[Pref.selectingPlayer - 1].SetActive(true);
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
        MoveInMobile();
        MoveInPC();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * horizontalSpeed * Time.deltaTime, Space.Self);
    }
    private void MoveInPC()
    {
        if(Input.GetKey(KeyCode.A))
        {
            
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.Self);
            _animator.SetFloat("Speed", 1);
            _spriteRenderer.flipX = true;

        }
        else if(Input.GetKey(KeyCode.D))
        {
            
            transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
            _animator.SetFloat("Speed", 1);
            _spriteRenderer.flipX = false;
        }
        else
        {
            _animator.SetFloat("Speed", 0);
        }
        if(Input.GetKey(KeyCode.W) && isGround == true)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpForce);
            _animator.SetBool("Jumping", true);
        }
    }
    private void MoveInMobile()
    {
        horizontalSpeed = Input.GetAxis("Horizontal");
        if (moveLeft)
        {
            
            horizontalSpeed = -1;
            _spriteRenderer.flipX = true;
            _animator.SetFloat("Speed", 1);
        }
        else if (moveRight)
        {
            
            horizontalSpeed = 1;
            _spriteRenderer.flipX = false;
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            horizontalSpeed = 0;
            _animator.SetFloat("Speed", 0);
        }
    }
    private void Jump()
    {
        //Nếu click button Jump và đang ở dưới đất là đúng 
        if (isGround == true)
        {
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, jumpForce);
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
        Jump();
    }
    public void UnClickJump()
    {
        //moveUp = false;
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
            _animator.SetBool("Jumping", false);
        }
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
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
            GameManager.Instance.Win();
        }
    }
}
