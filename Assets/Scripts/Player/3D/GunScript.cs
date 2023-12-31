using CartoonFX;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private SoundEffectSo _soundEffectSo;
    [SerializeField] private float range = 100f;

    private InputManager _inputManager;
    
    void Start()
    {
        _inputManager = InputManager.Instance;
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (_inputManager.PlayerShoot())
        {
            muzzleFlash.GetComponent<ParticleSystem>().Play();
            GameObject bullet = Instantiate(bulletPrefab, exitPoint.position, exitPoint.rotation.normalized, new RectTransform());
            BulletScript bulletController = bullet.GetComponent<BulletScript>();

            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out var hit, range))
            {
                bulletController.target = hit.point;
                bulletController.hit = true;
            }else
            {
                bulletController.target = fpsCam.transform.position + fpsCam.transform.forward * range;
                bulletController.hit = false;
            }

           // _soundEffectSo.Play(0);
        }
    }
}
