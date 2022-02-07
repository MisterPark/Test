using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{
    private Vector3 direction = Vector3.forward;// 캐릭터가 바라보는 방향, 스킬 사용시 사용 
    Animator animator;
   protected override void Start()
    {
        base.Start();
        Physics.gravity = new Vector3(0f, -10f, 0f);
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        Block();
        Attack();
        Jump();
        Move();
        Test();
       
    }

    void Forward_readjustment()
    {
        Vector3 forward = transform.position - Camera.main.transform.position;
        forward.y = 0f;
        forward.Normalize();
        transform.LookAt(transform.position + forward);
        direction = transform.forward;
    }

    void Jump()
    {
        if (!animator.GetBool("MovePossible"))
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!stats.JumpCheck)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * stats.JumpPower, ForceMode.Impulse);
                stats.JumpCheck = true;
            }
        }
        
    }

    void Move()
    {
        if (!animator.GetBool("MovePossible"))
            return;

        Run();
        Vector3 moveDirection = Vector3.zero;
        Vector3 forward = transform.position - Camera.main.transform.position;
        forward.y = 0f;
        forward.Normalize();
        Vector3 right = Vector3.Cross(Vector3.up, forward);

        if (Input.GetKey(KeyCode.W))
        {
            direction += forward;
            moveDirection += forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += -right;
            moveDirection += -right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += -forward;
            moveDirection += -forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += right;
            moveDirection += right;
        }
        // Move
        direction.Normalize();
        moveDirection.Normalize();
        transform.position += stats.MoveSpeed * moveDirection * Time.deltaTime;
        // Rotate
        transform.LookAt(transform.position + direction);

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        stats.Velocity = velocity;
        
        if(moveDirection == Vector3.zero)
            animator.SetFloat("Velocity", 0f);
        else
            animator.SetFloat("Velocity", 1f);
    }

    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (!animator.GetBool("Run"))
            {
                animator.SetBool("Run", true);
                stats.MoveSpeed = stats.RawMoveSpeed * 2f;
            }
        }
    }

    bool Attack()
    {
        if (!animator.GetBool("MovePossible"))
            return false;

        if (Input.GetMouseButtonDown(0))
        {
            if(animator.GetBool("MovePossible") && !animator.GetBool("Jump"))
            {
                Forward_readjustment();
                animator.SetInteger("Attack", 0);
                Vector3 tempPos = gameObject.transform.position + (gameObject.transform.forward * 1.2f);
                tempPos.y += 0.7f;
                DamageObjectController.Create_DamageObject(UnitStat.Team.Player, tempPos, 1.5f, 1.2f, 15f);
                
                return true;
            }
        }

        return false;
    }

    void Block()
    {
        // Block : -1 안막음 // 0 : 무기종류로 모션구별중 //  1 : 막기 시전모션 // 2 : 막고있음 // 3 : 막기 끝나는 모션 (부자연스러워서 스킵함)
        if (animator.GetInteger("Block") != 2)
        {
            if (!animator.GetBool("MovePossible"))
                return;

            if (Input.GetMouseButtonDown(1))
            {
                if (animator.GetBool("MovePossible") && !animator.GetBool("Jump"))
                {
                    Forward_readjustment();
                    animator.SetInteger("Block", 0);
                    animator.SetBool("MovePossible", false);
                }
            }
        }
        else
        {
            if (!Input.GetMouseButton(1))
            {
                animator.SetInteger("Block", 3);
            }
        }
    }

    void Test()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stats.Hp -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            stats.Mp -= 10;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
            stats.JumpCheck = false;
        }
    }
}
