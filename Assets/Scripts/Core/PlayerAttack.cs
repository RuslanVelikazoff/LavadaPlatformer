using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] 
    private float attackDelay = 1f;
    
    private bool isAttack = false;
    private bool withGun;

    private GameObject player;
    private Animator playerAnimator;

    [SerializeField] 
    private GameObject bulletPrefab;

    private void Update()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isAttack", isAttack);
        }
    }

    public void SetPlayerAnimator(Animator animator)
    {
        playerAnimator = animator;
    }

    public void IsPlayerWithGun(bool status)
    {
        withGun = status;
    }

    public void SetPlayerGameObject(GameObject player)
    {
        this.player = player;
    }

    public void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackCO());
            
            if (withGun)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<BulletPrefab>().SpawnBullet(player.transform.rotation.y);
                Debug.Log(player.transform.rotation.y);
            }
            else
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(this.gameObject.transform.position,
                    1f, LayerMask.GetMask("Enemy"));
                for (int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i].gameObject);
                }
            }
        }
    }

    private IEnumerator AttackCO()
    {
        isAttack = true;

        yield return new WaitForSeconds(attackDelay);

        isAttack = false;
    }
}
