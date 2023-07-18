using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    [SerializeField] private GameObject projectileDecal;
    [SerializeField] private float projectileSpeed = 55f;
    [SerializeField] private int projectileDamage = 10;
    private float timeToDestroy = 3f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
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

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contactPoint = other.GetContact(0); ;

        if (other.gameObject.CompareTag("Enemy").Equals(true))
        {
           //other.gameObject.GetComponentInParent<EnemyStats>().EnemyTakeDamage(projectileDamage);
        }
        else
        {
            Instantiate(projectileDecal, contactPoint.point + contactPoint.normal*.0001f, Quaternion.LookRotation(contactPoint.normal));
        }
        Destroy(gameObject);
    }
}
