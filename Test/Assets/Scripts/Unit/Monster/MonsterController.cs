using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterState { Idle, Move, Attack,}

public class MonsterController : UnitController
{
    protected UnitStat stat;
    public Spawner spawner { get; set; }
    public SpotSpawner spotSpawner { get; set;}
    protected Animator animator;
    public float SearchDistance;
    public float ApproachDistance;
    public float AttackRange;
    public float SpawnRange;
    public Vector3 SpawnPosition;
    private MonsterState monsterState;
    [SerializeField] bool isSearch;
    [SerializeField] bool isOutRange;
    Vector3 direction;
    float distance;

    GameObject player;


    protected void OnEnable()
    {
        isSearch = false;
    }
    protected void OnDisable()
    {
    }

    protected override void Start()
    {
        monsterState = MonsterState.Idle;
        isOutRange = false;
        stat = GetComponent<UnitStat>();
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        SpawnPosition = transform.position;
    }

    protected override void Update()
    {
        if (stat.Hp < 0)
        {
            if(spawner != null)
             spawner.Remove(this.gameObject); 
            if(spotSpawner!=null)
                spotSpawner.Remove(this.gameObject);
            stat.Hp = stat.MaxHp;
        }
        if (!isSearch)
        {
            if (!isOutRange)
            {
                Search();
            }
            else
            {
                MoveToTarget(SpawnPosition);
            }
        }
        else
        {
            if (!OutSpawnRangeCheck())
            {
                //ChangeState(MonsterState.Move);
                Move(); 
            }
        }
    }

    public void ChangeState(MonsterState newState)
    {
        if (newState == monsterState)
            return;
        StopCoroutine(monsterState.ToString());
        monsterState = newState;
        StartCoroutine(newState.ToString());
    }

      protected void Search()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < SearchDistance)
        {
            isSearch = true;
        }
    }


    private Vector3 SetAngle(float radius, int angle)
    {
        Vector3 position = Vector3.zero;

        position.x = Mathf.Cos(angle) * radius;
        position.z=Mathf.Sin(angle)*radius;
        return position;
    }

    
    protected bool OutSpawnRangeCheck()
    {
        float spawnToDistance;
        spawnToDistance = Vector3.Distance(transform.position, SpawnPosition);
        if (spawnToDistance > SpawnRange)
        {
            isSearch = false;
            isOutRange = true;
            return true; 
        }
        return false;
    }
    protected void DirectedToPlayer()
    {
        direction = player.transform.position - transform.position;
        direction.Normalize();
        direction.y = 0;
        transform.forward = direction;
    }
    private Vector3 DirectToTarget(Vector3 target)
    {
        direction = target - transform.position;
        direction.Normalize();
        direction.y = 0;
        return direction;
    }

    protected void Move()
    {
        ChangeState(MonsterState.Move);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > ApproachDistance&&animator.GetInteger("Attack")==-1)
        {
            animator.SetBool("Walk", true);
            stat.MoveSpeed = stat.RawMoveSpeed;
            direction = player.transform.position - transform.position;
            direction.Normalize();
            direction.y = 0;
            transform.forward = direction;
            transform.position += direction * stat.MoveSpeed * Time.deltaTime;
        }
        else
        {
            //»ç°Å¸®
            ChangeState(MonsterState.Attack);
            stat.MoveSpeed = 0;
        }
    }

    protected void MoveToTarget(Vector3 target)
    {
        float distance = Vector3.Distance(target, transform.position);
        if (distance < 0.2)
        {
            isOutRange = false;
            stat.MoveSpeed = 0;
            animator.SetBool("Walk", false);
            return;
        }
        direction = DirectToTarget(target);
        transform.forward = direction;
        animator.SetBool("Walk", true);
        if (stat.MoveSpeed != 0)
        {
            stat.MoveSpeed=stat.RawMoveSpeed*2;
            stat.Hp = stat.MaxHp;
            transform.position += direction * stat.MoveSpeed * Time.deltaTime;
        }
    }


    virtual protected bool Attack()
    {
        return false;
    }
    
    public void Remove(GameObject gameObject)
    {
        ObjectPool.Instance.Free(gameObject);
    }
}

