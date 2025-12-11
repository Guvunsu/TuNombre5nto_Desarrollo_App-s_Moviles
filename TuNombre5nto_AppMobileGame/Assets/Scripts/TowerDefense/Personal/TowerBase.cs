using System.Collections;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public enum TowerState
    {
        Idle,
        Attacking,
        Destroyed
    }

    [Header("Stats")]
    public int maxHealth = 100;
    public int damage = 20;
    public float attackRate = 1f;
    public float attackRange = 3f;

    [Header("Visuals")]
    public SpriteRenderer spriteRenderer;

    [Header("Attack Settings")]
    public GameObject projectilePrefab;
    public bool useProjectiles = true;

    private TowerState state = TowerState.Idle;
    private int currentHealth;
    private bool canAttack = true;

    void Start()
    {
        currentHealth = maxHealth;
        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        while (state != TowerState.Destroyed)
        {
            switch (state)
            {
                case TowerState.Idle:
                    LookForEnemies();
                    break;

                case TowerState.Attacking:
                    if (canAttack)
                        StartCoroutine(AttackRoutine());
                    break;
            }
            yield return null;
        }
    }

    void LookForEnemies()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (var h in hits)
        {
            if (h.CompareTag("Enemy"))
            {
                state = TowerState.Attacking;
                return;
            }
        }
    }

    IEnumerator AttackRoutine()
    {
        canAttack = false;

        GameObject target = GetClosestEnemy();

        if (target != null)
        {
            if (useProjectiles)
            {
                ShootProjectile(target.transform);
            } else
            {
                // Daño directo al enemigo
                EnemyBase e = target.GetComponent<EnemyBase>();
                if (e != null)
                    e.TakeDamage(damage);
            }
        }

        yield return new WaitForSeconds(attackRate);
        canAttack = true;
        state = TowerState.Idle;
    }

    void ShootProjectile(Transform target)
    {
        if (projectilePrefab == null) return;

        GameObject p = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile proj = p.GetComponent<Projectile>();

        if (proj != null)
            proj.Initialize(target, damage);
    }

    GameObject GetClosestEnemy()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);

        float minDist = Mathf.Infinity;
        GameObject closest = null;

        foreach (var h in hits)
        {
            if (!h.CompareTag("Enemy")) continue;

            float d = Vector2.Distance(transform.position, h.transform.position);
            if (d < minDist)
            {
                minDist = d;
                closest = h.gameObject;
            }
        }
        return closest;
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
            DestroyTower();
    }

    void DestroyTower()
    {
        state = TowerState.Destroyed;
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Debug.Log("UFO detectado: " + collision.gameObject);
        } 
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Debug.Log("UFO salió del rango");
        }   
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
