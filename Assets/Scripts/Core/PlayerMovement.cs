using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField] 
    private float normalSpeed;
    [SerializeField]
    private float jumpForce;
    
    private float speed;

    private Vector2 moveDirection;

    private bool isMove;
    private bool isGround;

    private const string PLATFORM_TAG = "Platform";

    private void Start()
    {
        speed = 0f;
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    public void MovePlayerRight()
    {
        if (speed <= 0f)
        {
            speed = normalSpeed;
        }
    }

    public void MovePlayerLeft()
    {
        if (speed >= 0f)
        {
            speed = -normalSpeed;
        }
    }

    public void ResetMove()
    {
        speed = 0f;
    }

    public void JumpPlayer()
    {
        if (isGround)
        {
            rigidbody.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(PLATFORM_TAG))
        {
            isGround = true;
        }
    }
}
