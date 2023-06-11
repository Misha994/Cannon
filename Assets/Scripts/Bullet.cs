using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int bounceCount;
    [SerializeField] private int maxBounces = 3;
    [SerializeField] private float gravity;
    [SerializeField] private float bounceFactor = 0.8f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private GameObject treil;

    private void Update()
    {
        MoveBullet();
    }

    public void MoveBullet()
    {
        velocity.y -= gravity * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;
    }

    public void SetValues(Vector3 velocity, float gravity, Quaternion rotation)
    {
        this.velocity = velocity;
        this.gravity = gravity;
        transform.rotation = rotation;
    }
    private void RotationRelativeContactPlane(Collider other)
    {
        Vector3 heightOffset = Vector3.up * 0.001f;
        Vector3 contactPoint = other.ClosestPoint(transform.position) + heightOffset;
        Vector3 surfaceNormal1 = other.transform.up;
        Quaternion contactRotation = Quaternion.FromToRotation(Vector3.up, surfaceNormal1);

        if (other.transform.rotation == Quaternion.identity)
        {
            Instantiate(treil, contactPoint, treil.transform.rotation);
        }
        else
        {
            Instantiate(treil, contactPoint, contactRotation);
        }
    }

    private void BounceCounter(Collider other)
    {
        if (bounceCount < maxBounces)
        {
            Collider currentCollider = GetComponent<Collider>();

            float penetrationDepth;
            Vector3 normalVector;

            if (Physics.ComputePenetration(currentCollider, transform.position, transform.rotation,
                other, other.transform.position, other.transform.rotation,
                out normalVector, out penetrationDepth))
            {
                Debug.Log(normalVector);
            }
            Vector3 surfaceNormal = normalVector;

            Vector3 bounceDirection = Vector3.Reflect(velocity.normalized, surfaceNormal);

            velocity = bounceDirection * velocity.magnitude * bounceFactor;

            bounceCount++;
        }
        else
        {
            Instantiate(particle, transform.position, transform.rotation);
            bounceCount = 0;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RotationRelativeContactPlane(other);
        BounceCounter(other);
    }
}
