using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField] 
    private float speed;
    
    [SerializeField] 
    private Rigidbody2D rigidbody;

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.LoseGame();
        }
    }
}
