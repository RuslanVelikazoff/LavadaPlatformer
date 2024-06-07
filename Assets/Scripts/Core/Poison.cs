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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            PlayerHealthBar.Instance.DamagePlayer(30);
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
        }
    }
}
