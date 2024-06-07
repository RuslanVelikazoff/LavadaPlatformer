using UnityEngine;

public class CoinPrefab : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            CoinManager.Instance.AddCoin();
        }
    }
}
