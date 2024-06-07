using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.Play("Explosion");
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            PlayerHealthBar.Instance.DamagePlayer(40);
        }
    }
}
