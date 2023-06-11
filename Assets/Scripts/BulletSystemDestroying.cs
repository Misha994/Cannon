using System.Collections;
using UnityEngine;

public class BulletSystemDestroying : MonoBehaviour
{
    public float destroyDelay = 2f;

    void Start()
    {
        StartCoroutine(DestroyObjectAfterDelay());
    }

    IEnumerator DestroyObjectAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        gameObject.SetActive(false);
    }
}
