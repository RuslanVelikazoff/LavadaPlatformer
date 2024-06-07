using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField] 
    private float speed = -3;

    [SerializeField] 
    private Rigidbody2D rigidbody;

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("RightWall"))
        {
            speed = -speed;
            this.gameObject.transform.rotation = new Quaternion(
                this.gameObject.transform.rotation.x,
                0,
                this.gameObject.transform.rotation.z, 0);
        }

        if (other.gameObject.CompareTag("LeftWall"))
        {
            speed = -speed;
            this.gameObject.transform.rotation = new Quaternion(
                this.gameObject.transform.rotation.x,
                180,
                this.gameObject.transform.rotation.z, 0);
        }
    }
}
