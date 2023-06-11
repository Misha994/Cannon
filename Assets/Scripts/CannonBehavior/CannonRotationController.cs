using UnityEngine;

public class CannonRotationController : MonoBehaviour
{

    [SerializeField] private float horizontalRotationSpeed = 5f;
    [SerializeField] private float verticalRotationSpeed = 5f;

    [SerializeField] private float maxVerticalAngle = 45f;
    [SerializeField] private float minVerticalAngle = -45f;

    [SerializeField] private float currentVerticalAngle = 0; 

    [SerializeField] private Transform turretBase;
    [SerializeField] private Transform cannon;

    void Update()
    {
        CannonRotation();
    }

    private void CannonRotation()
    {
        float horizontalRotationInput = Input.GetAxis("Horizontal");
        float verticalRotationInput = Input.GetAxis("Vertical");

        // Rotation horizontally
        Quaternion horizontalRotation = Quaternion.Euler(0f, horizontalRotationInput * horizontalRotationSpeed * Time.deltaTime, 0f);
        turretBase.rotation *= horizontalRotation;

        // Rotation vertically 
        float verticalRotation = verticalRotationInput * verticalRotationSpeed * Time.deltaTime;
        currentVerticalAngle += verticalRotation;
        currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, minVerticalAngle, maxVerticalAngle);
        cannon.localRotation = Quaternion.Euler(-currentVerticalAngle, 0f, 0f);
    }
}