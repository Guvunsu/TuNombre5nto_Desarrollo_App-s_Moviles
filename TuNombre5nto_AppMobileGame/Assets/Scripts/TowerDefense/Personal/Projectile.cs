using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;

    private Transform target;
    private int damage;

    public void Initialize(Transform t, int dmg)
    {
        target = t;
        damage = dmg;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            EnemyBase e = target.GetComponent<EnemyBase>();
            if (e != null)
                e.TakeDamage(damage);

            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<EnemyBase>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
