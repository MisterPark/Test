using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToPlayer : MonoBehaviour
{

    GameObject player;

    UnitStat stats;
    Animator animator;
    Vector3 direction;
    public float SearchDistance = 5;
    public float MoveSpeed = 2;
    public float ApproachDistance = 2;
    float distance;
    float moveSpeed;
    bool isSearch;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<UnitStat>();
        player = GameObject.Find("Player");
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();        
        moveSpeed = MoveSpeed;
        isSearch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSearch)
            Search();
        else
            Move();
    }

    void Move()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > ApproachDistance)
            {
                moveSpeed = MoveSpeed;
                direction = player.transform.position - transform.position;
                direction.Normalize();
                direction.y = 0;

                animator.SetFloat("Velocity", moveSpeed);
                if (moveSpeed != 0)
                {
                    transform.forward = direction;
                    transform.position += direction * moveSpeed * Time.deltaTime;
                }
            }
            else
            {
                moveSpeed = 0;
                animator.SetFloat("Velocity", moveSpeed);
            }
       
    }

    void Search()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < SearchDistance)
        {
            isSearch = true;
        }
    }
}
