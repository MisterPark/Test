using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum MonsterState { None, Idle, Wander,}

public class MonsterController : UnitController
{
    protected UnitStat stat;
    public Spawner spawner { get; set; }
    Animator animator;
    public float SearchDistance;
    public float ApproachDistance;
    public float AttackRange;
    public float SpawnRange;
    public Vector3 SpawnPosition;
    //private MonsterState monsterState;
    [SerializeField] bool isSearch;
    [SerializeField] bool isOutRange;
    Vector3 direction;
    float distance;

    GameObject player;


    protected void OnEnable()
    {
        
    }
    protected void OnDisable()
    {
        isSearch = false;
        
    }

    protected override void Start()
    {
        //monsterState = MonsterState.None;
        isOutRange = false;
        SpawnRange = 15f;
        stat = GetComponent<UnitStat>();
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        SpawnPosition = transform.position;
    }

    protected override void Update()
    {
        
        if (stat.Hp < 0)
        {
            spawner.Remove(this.gameObject); 
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
        else if(!OutSpawnRangeCheck())
        {
            Move();            
        }
        

    }


    protected void Search()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < SearchDistance)
        {
            isSearch = true;
        }
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

    protected void Move()
    {
       
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > ApproachDistance)
        {
            stat.MoveSpeed = stat.RawMoveSpeed;
            direction = player.transform.position - transform.position;
            direction.Normalize();
            direction.y = 0;

            animator.SetFloat("Velocity", stat.MoveSpeed);
            if (stat.MoveSpeed != 0)
            {
                transform.forward = direction;
                transform.position += direction * stat.MoveSpeed * Time.deltaTime;
            }
        }
        else
        {
            //»ç°Å¸®
            Attack();
            stat.MoveSpeed = 0;
            animator.SetFloat("Velocity", stat.MoveSpeed);
        }
    }

    protected void MoveToTarget(Vector3 target)
    {
        float distance = Vector3.Distance(target, transform.position);

        if (distance < 0.2)
        {
            isOutRange = false;
            stat.MoveSpeed = 0;
            return;
        }
            
        direction = target - transform.position;
        direction.Normalize();
        direction.y = 0;

        animator.SetFloat("Velocity", stat.MoveSpeed);
        if (stat.MoveSpeed != 0)
        {
            transform.forward = direction;
            transform.position += direction * stat.MoveSpeed * Time.deltaTime;
        }

    }


    protected bool Attack()
    {
        DirectedToPlayer();
        if (animator.GetInteger("Attack")==-1)
        { 
            animator.SetInteger("Attack", 0);
            Vector3 tempPos = gameObject.transform.position + (gameObject.transform.forward * AttackRange);
            tempPos.y += 0.7f;
            DamageObjectController.Create_DamageObject(gameObject, UnitStat.Team.Enemy, tempPos, 0.5f, 1.2f, 15f);
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
}
