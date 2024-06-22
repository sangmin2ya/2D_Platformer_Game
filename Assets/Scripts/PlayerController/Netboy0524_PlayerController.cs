using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Netboy0524_PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    private Rigidbody2D _rigidbody;
    private bool _isGrounded = true;
    private float _runSpeed = 10f;
    private float _walkSpeed = 6f;
    private float _jumpSpeed = 20f;
    private float _jumpInput = 0f;
    private int _jumpCount;
    public static bool _isDead { get; set; } = false;
    public static bool _gotItem { get; private set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Netboy0524_CameraController._whileCutScene)
        {
            GroundCheck();
            PlayerMove();
        }
    }
    /// <summary>
    /// 플레이어 이동함수
    /// </summary>
    private void PlayerMove()
    {
        float playerVel = 0;
        float moveInput = Input.GetAxis("Horizontal");
        if (_isGrounded == true)
        {
            _jumpCount = 0; //지면에 닿으면 점프카운트 초기화
            if (moveInput != 0)
            {
                playerVel = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //점프 방향 저장
                _jumpInput = moveInput;
                _rigidbody.AddForce(new Vector2(0f, _jumpSpeed), ForceMode2D.Impulse);
                _jumpCount++;
            }
        }
        else
        {
            //공중에서 방향전환시 속도 감소
            if (moveInput != 0 && Mathf.Sign(moveInput) != Mathf.Sign(_jumpInput))
            {
                playerVel = 2f;
            }
            //방향유지시 그대로
            else
            {
                playerVel = Input.GetKey(KeyCode.LeftShift) ? _runSpeed : _walkSpeed;
            }
            //이단 점프 활성화
            if (_gotItem && Input.GetKeyDown(KeyCode.Space) && _jumpCount < 2)
            {
                // 점프 방향 저장
                _jumpInput = moveInput;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f); // 이전 y 속도 무효화
                _rigidbody.AddForce(new Vector2(0f, _jumpSpeed), ForceMode2D.Impulse);
                _jumpCount++;
            }
        }
        _rigidbody.velocity = new Vector2(moveInput * playerVel, _rigidbody.velocity.y);
    }
    //땅(layer가 ground인 오브젝트)에 닿아있는지 체크
    private void GroundCheck()
    {
        _isGrounded = Physics2D.OverlapCircle(transform.position, 1f, _ground);
    }
    /// <summary>
    /// 아래로 떨어지거나, 장애물에 닿았을경우 Gameover / 아이템 획득시 아이템 소유
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Stage") && other.transform.name == "DeadZone")
        {
            _isDead = true;
            _gotItem = false;
        }
        if (other.CompareTag("Item"))
        {
            _gotItem = true;
            other.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Triangle"))
        {
            _isDead = true;
            _gotItem = false;
        }
    }
}
