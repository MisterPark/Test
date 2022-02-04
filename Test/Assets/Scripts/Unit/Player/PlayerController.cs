using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitController
{
    public UnitStat stats { get; set; }
    private Rigidbody rigidbody;
    private Vector3 direction = Vector3.forward;// 캐릭터가 바라보는 방향, 스킬 사용시 사용 
    Animator animator;
   protected override void Start()
    {
        Physics.gravity = new Vector3(0f, -10f, 0f);
        stats = GetComponent<UnitStat>();
        rigidbody = GetComponent<Rigidbody>();
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        Attack();
        Jump();
        Move();
        Test();
    }

    void Jump()
    {
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
            direction = forward;
            moveDirection = forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = -right;
            moveDirection = -right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = -forward;
            moveDirection = -forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = right;
            moveDirection = right;
        }
        // Move
        direction.Normalize();
        transform.position += stats.MoveSpeed * moveDirection * Time.deltaTime;
        // Rotate
        transform.LookAt(transform.position + direction);

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        stats.Velocity = velocity;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Terrain"))
        {
            stats.JumpCheck = false;
        }
    }

    void Test()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            stats.Hp -= 10;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            stats.Mp -= 10;
        }
    }

    void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
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
        if (Input.GetMouseButtonDown(1))
        {
            if(animator.GetBool("MovePossible") && !animator.GetBool("Jump"))
            {
                animator.SetInteger("Attack", 1);
                return true;
            }
        }

        return false;
    }
}
