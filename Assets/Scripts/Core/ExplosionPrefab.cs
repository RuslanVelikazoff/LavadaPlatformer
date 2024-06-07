using System.Collections;
using UnityEngine;

public class ExplosionPrefab : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ExplosionDestroy());
    }

    private IEnumerator ExplosionDestroy()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
