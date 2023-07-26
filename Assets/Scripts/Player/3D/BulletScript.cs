using System;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 200f;
    [SerializeField] private float projectileDamage = 20f;
    [SerializeField] private GameObject projectileHitParticle;
    [SerializeField] private SoundEffectSo _soundEffectSo;
    private float timeToDestroy = 3f;
    private AudioSource source;
    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Start()
    {
        source = _soundEffectSo.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < .01f)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            Entity enemy = other.gameObject.GetComponentInParent<Entity>();
            Instantiate(projectileHitParticle, transform.position, other.transform.rotation);
            enemy.TakeDamage(projectileDamage);
        }
    }
}
