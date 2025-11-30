using UnityEngine;
using UnityEngine.Rendering;

// hacer copy paste para diferentes Ufos, este sera la base de los enemigos 
public class CycleLifeBasicEnemy : MonoBehaviour
{
    public enum UFO_FSM
    {
        MOVING,
        STOP,
        HIT,
        DYING
    }
    [SerializeField] protected UFO_FSM fsm_UFO;

    [Header("MoveEnemy")]
    public float speedMove = 8f;
    public float timeGame = 0f;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    private Vector3 fixedPosition;

    [Header("Enemy Components")]
    //[SerializeField] GameObject basicUFO;
    private Rigidbody2D rb;

    void Start()
    {
        //basicUFO = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody2D>();
        fsm_UFO = UFO_FSM.MOVING;
        timeGame = 0f;
    }
    void Update()
    {
        timeGame += Time.deltaTime;
        switch (fsm_UFO)
        {
            case UFO_FSM.MOVING:
                MoveUFOForwardUntilMageTower();
                break;
            case UFO_FSM.STOP:
                StopUFO();
                break;
            case UFO_FSM.HIT:
                AttackUFO();
                break;
            case UFO_FSM.DYING:
                MeidemMeidemTheyHitMe();
                break;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BasicMageTower")
        {
            fsm_UFO = UFO_FSM.HIT;
        } 
    }
    public void AttackUFO()
    {
        StopUFO();
        // TODO logica de ataque
        //animacion de ataque
    }
    public void MoveUFOForwardUntilMageTower()
    {
        transform.Translate(Vector2.down * speedMove * Time.deltaTime);
    }
    public void StopUFO()
    {
        fixedPosition = transform.position;
        transform.position = fixedPosition;
    }
    public void MeidemMeidemTheyHitMe()
    {
        //animacion de muerte
    }
}
