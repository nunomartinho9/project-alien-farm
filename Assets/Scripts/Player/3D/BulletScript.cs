using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 55f;
    [SerializeField] private float projectileDamage = 10f;
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
        Debug.Log("hit");
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            Entity enemy = other.gameObject.GetComponentInParent<Entity>();
            enemy.TakeDamage(projectileDamage);
        }
        Destroy(gameObject);
    }
}
