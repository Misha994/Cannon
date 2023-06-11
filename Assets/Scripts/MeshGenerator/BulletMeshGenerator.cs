using System.Collections;
using UnityEngine;

public abstract class BulletMeshGenerator : MonoBehaviour
{
    public abstract IEnumerator GenerateMesh();

    private void Start()
    {
        StartCoroutineWrapper();
    }

    public void StartCoroutineWrapper()
    {
        StartCoroutine(GenerateMesh());
    }
}
