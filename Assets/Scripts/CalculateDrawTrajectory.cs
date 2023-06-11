using UnityEngine;

public class CalculateDrawTrajectory : MonoBehaviour
{
    [SerializeField] private int steps = 100;
    [SerializeField] private float stepInterval = 0.1f;
    [SerializeField] private LineRenderer lineRenderer;

    public  void DrawTrajectory(float initialSpeed, float gravity, Transform GunTransform)
    {
        Vector3 initialPosition = GunTransform.position;
        Vector3 initialVelocity = GunTransform.forward * initialSpeed;

        lineRenderer.positionCount = steps;

        for (int i = 0; i < steps; i++)
        {
            float time = stepInterval * i;

            Vector3 displacement = initialVelocity * time + 0.5f * -Vector3.up * gravity * time * time;
            Vector3 position = initialPosition + displacement;

            position = initialPosition + displacement;
            lineRenderer.SetPosition(i, position);
        }

    }
}
