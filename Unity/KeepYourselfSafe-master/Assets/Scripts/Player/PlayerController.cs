using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private static PlayerController _instance; 
    public static PlayerController Instance => _instance;
    
    //Get the child GroundCheckCollider
    [Header("References")]
    [SerializeField] private Transform _groundCheckCollider;
    [SerializeField] private Transform _respawnPoint;
    
    [Header("Values")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private float _gravity = 1f;
    
    [SerializeField] private bool _isGrounded = false;
    
    private Rigidbody2D _rigidbody2D;
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        if (_instance == null) { _instance = this; }
        else { Destroy(gameObject); }
    }

    // Update is called once per frame
    void Update()
    {
        RespawnPlayer();
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        //_isGround = Physics2d.Overlap
        _isGrounded = Physics2D.OverlapBox(_groundCheckCollider.position, _groundCheckCollider.localScale, 0f,
            LayerMask.GetMask("Ground"));
    }
    void PlayerMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(horizontalInput * _speed, _rigidbody2D.velocity.y);
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    void PlayerPhysicsMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalInput != 0)
        {
            _rigidbody2D.AddForce(Vector2.right * horizontalInput * 200, ForceMode2D.Impulse);
        }
    }

    void RespawnPlayer()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = _respawnPoint.position;
        }
    }

    public void PlayerIsDead()
    {
        transform.position = _respawnPoint.position;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ScreenEdge"))
        {
            transform.position = _respawnPoint.position;
        }
    }
    private void OnDrawGizmos()
    {
        //Draw a circle to show the ground check position
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_groundCheckCollider.position, _groundCheckCollider.localScale);
    }
}
