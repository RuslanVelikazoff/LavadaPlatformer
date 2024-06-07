using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            GameManager.Instance.LoseGame();
        }
    }
}
