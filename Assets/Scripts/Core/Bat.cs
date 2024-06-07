using System.Collections;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField] 
    private float poisonLifeTime = 2.5f;
    
    [SerializeField] 
    private GameObject poisonPrefab;

    private void Start()
    {
        StartCoroutine(BatAttack());
    }

    private IEnumerator BatAttack()
    {
        GameObject poison = Instantiate(poisonPrefab, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(poisonLifeTime);

        if (poison != null)
        {
            Destroy(poison);
        }

        StartCoroutine(BatAttack());
    }
}
