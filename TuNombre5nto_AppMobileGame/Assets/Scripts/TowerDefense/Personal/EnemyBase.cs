using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class EnemyBase : MonoBehaviour
{
    public enum UFO_FSM
    {
        MOVING,
        HIT,
        DYING
    }

    [Header("Enemy FSM")]
    [SerializeField] protected UFO_FSM fsm_UFO = UFO_FSM.MOVING;

    [Header("Enemy Stats")]
    public float speedMove = 2f;
    public int maxHealth = 5;
    public int rewardPoints = 10;
    public float attackCooldown = 1.5f;

    [Header("Path LERP (Asignado por SpawnManager)")]
    private Transform pointA;
    private Transform pointB;
    private float t = 0f;

    [Header("Attack")]
    public int damageToTower = 10;
    public bool continuousDamage = true;

    [Header("Lane System")]
    public LifeSystemLane laneSystem;

    private int currentHealth;
    private bool isAttacking = false;

    void Start()
    {
        currentHealth = maxHealth;
        fsm_UFO = UFO_FSM.MOVING;
    }

    void Update()
    {
        switch (fsm_UFO)
        {
            case UFO_FSM.MOVING:
                MoveForward();
                break;

            case UFO_FSM.HIT:
                if (!isAttacking)
                    StartCoroutine(AttackRoutine());
                break;

            case UFO_FSM.DYING:
                Die();
                break;
        }
    }
    void MoveForward()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogWarning("EnemyBase: Path no asignado. Usa EnemySpawnManager.SetPath().");
            return;
        }

        t += Time.deltaTime * speedMove;
        transform.position = Vector3.Lerp(pointA.position, pointB.position, t);

        // Al llegar al final del camino
        if (t >= 1f)
        {
            if (laneSystem != null)
                laneSystem.DamageLane(1);

            Destroy(gameObject);
        }
    }
    IEnumerator AttackRoutine()
    {
        isAttacking = true;

        yield return new WaitForSeconds(attackCooldown);

        isAttacking = false;
    }
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
            fsm_UFO = UFO_FSM.DYING;
    }
    void Die()
    {
        EconomyManager.instance.AddMoney(rewardPoints);
        Destroy(gameObject);
    }
    public void SetPath(Transform a, Transform b)
    {
        pointA = a;
        pointB = b;
        t = 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            fsm_UFO = UFO_FSM.HIT;

            TowerBase tower = collision.GetComponent<TowerBase>();
            if (tower != null)
                tower.TakeDamage(damageToTower);
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Heart"))
        {
            fsm_UFO = UFO_FSM.HIT;

            if (laneSystem != null)
                laneSystem.DamageLane(1);
        }
    }
}