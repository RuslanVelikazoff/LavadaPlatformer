using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rigidbody;

    private float speed = 4.5f;
    
    private float lifeTime = 3f;

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    public void SpawnBullet(float rotationY)
    {
        if (rotationY >= 1)
        {
            speed = -speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.Play("Kill");
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
        }
    }
}
