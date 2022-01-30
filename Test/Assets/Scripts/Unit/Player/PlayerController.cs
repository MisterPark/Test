using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UnitStat stats { get; set; }
    private Rigidbody rigidbody;
    private Vector3 direction = Vector3.forward;// 캐릭터가 바라보는 방향, 스킬 사용시 사용 
    void Start()
    {
        Physics.gravity = new Vector3(0f, -15f, 0f);
        stats = GetComponent<UnitStat>();
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
