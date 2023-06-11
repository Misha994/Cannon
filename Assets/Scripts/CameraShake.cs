using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeIntensity = 0.5f;

    private Vector3 originalPosition;
    private float shakeTimer = 0f;

    private void Start()
    {
        originalPosition = transform.localPosition;

    }

    private void Update()
    {
        if (shakeTimer > 0)
        {
            transform.localPosition = originalPosition + Random.insideUnitSphere * shakeIntensity;

            shakeTimer -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = originalPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            ShakeCamera();
        }
    }

    public void ShakeCamera()
    {
        shakeTimer = shakeDuration;
    }
}