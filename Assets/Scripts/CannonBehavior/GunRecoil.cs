using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    [SerializeField] private ShootingController shootingController;
    [SerializeField] private Transform gunBarrel;
    [SerializeField] private float recoilForce = 1f; 

    private Vector3 initialPosition; 
    private bool isRecoiling = false; 

    private void Start()
    {
        initialPosition = gunBarrel.localPosition;
        shootingController.gunFier += Recoil;
    }

    private void Update()
    {
        if (isRecoiling)
        {
            // Move gun back
            gunBarrel.Translate(Vector3.back * recoilForce * Time.deltaTime);

            // Check reach the maximum deviation
            if (gunBarrel.localPosition.z <= -recoilForce)
            {
                // Return gun to original position
                gunBarrel.localPosition = initialPosition;
                isRecoiling = false;
            }
        }
    }

    public void Recoil()
    {
        gunBarrel.localPosition = initialPosition;
        isRecoiling = true;
    }

    private void OnDestroy()
    {
        shootingController.gunFier -= Recoil;
    }
}