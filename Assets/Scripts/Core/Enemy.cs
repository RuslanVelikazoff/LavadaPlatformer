using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.Play("Hit");
            PlayerHealthBar.Instance.DamagePlayer(20);
        }
    }
}
