using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : UnitController
{
    protected UnitStat stat;
    public Spawner spawner { get; set; }
    Animator animator;
    public float SearchDistance;
    public float ApproachDistance;
    public float AttackRange;
    [SerializeField] bool isSearch;
    Vector3 direction;
    float distance;

    GameObject player;
    // Start is called before the first frame update
    protected override void Start()
    {
        stat = GetComponent<UnitStat>();
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    protected override void Update()
    {
        
        if (stat.Hp < 0)
        {
            spawner.Remove(this.gameObject); 
            stat.Hp = stat.MaxHp;
        }
        if (!isSearch)
        {
            Search();
        }
        else
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

    protected bool Attack()
    {
        DirectedToPlayer();
        if (animator.GetInteger("Attack")==-1)
        { 
            animator.SetInteger("Attack", 0);
            Vector3 tempPos = gameObject.transform.position + (gameObject.transform.forward * AttackRange);
            tempPos.y += 0.7f;
            DamageObjectController.Create_DamageObject(UnitStat.Team.Enemy, tempPos, 0.5f, 1.2f, 15f);
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
