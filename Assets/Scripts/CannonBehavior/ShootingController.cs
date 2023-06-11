using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private Transform gun;
    [SerializeField] private CalculateDrawTrajectory calculateBulletTrajectory;
    [SerializeField] private DynamicObjectPool objectPool; 

    [SerializeField] private Slider recoilSlider;
    [SerializeField] private TMP_Text text;

    public delegate void GunFier();
    public GunFier gunFier;

    private void Start()
    {
        recoilSlider.onValueChanged.AddListener(ChangePower);
    }

    private void Update()
    {
        if (calculateBulletTrajectory != null)
        {
            calculateBulletTrajectory.DrawTrajectory(initialSpeed, gravity, gun);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Vector3 test = gun.forward * initialSpeed;
        GameObject projectile = objectPool.GetObject(transform.position, Quaternion.identity);
        
        projectile.GetComponent<Bullet>().SetValues(test, gravity, gun.rotation);
        projectile.SetActive(true);

        gunFier?.Invoke();
    }

    private void ChangePower(float value)
    {
        initialSpeed = value;
        text.text = initialSpeed.ToString("00");
    }
}