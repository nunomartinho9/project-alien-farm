using CartoonFX;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform exitPoint;
    [SerializeField] private GameObject muzzleFlash;
    
    [SerializeField] private float range = 100f;

    private InputManager _inputManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputManager.PlayerShoot())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.GetComponent<ParticleSystem>().Play();
        GameObject bullet = Instantiate(bulletPrefab, exitPoint.position, exitPoint.rotation.normalized, new RectTransform());
        BulletScript bulletController = bullet.GetComponent<BulletScript>();
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            bulletController.target = hit.point;
            bulletController.hit = true;
            Debug.Log(hit.transform.name);
        }else
        {
            bulletController.target = fpsCam.transform.position + fpsCam.transform.forward * range;
            bulletController.hit = false;
        }
    }
}
