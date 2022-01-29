using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    UnitStat stats;
    private Rigidbody rigidbody;
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0f, -15f, 0f);
        stats = GetComponent<UnitStat>();
        rigidbody = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }

    void Jump()
    {
        float fallSpeed = rigidbody.velocity.y;
        if (fallSpeed < 1f && 0f <= fallSpeed)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * stats.JumpPower, ForceMode.Impulse);
            }
        }
    }

    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // Rotate
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= stats.MoveSpeed;
        //if (velocity.magnitude != 0)
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //transform.LookAt(transform.position + velocity);
            Vector3 test = transform.position;
            test.x += mainCamera.transform.forward.x;
            test.z += mainCamera.transform.forward.z;
            transform.LookAt(test);
        }

        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += transform.forward * velocity.z;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += transform.right * velocity.x;

        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += transform.forward * velocity.z;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += transform.right * velocity.x;
        }
        // Move
        direction.Normalize();
        Debug.Log(direction);
        velocity = stats.MoveSpeed * direction;
        transform.position += velocity * Time.deltaTime;
        // 애니메이션 재조정
        transform.LookAt((velocity * Time.deltaTime) + transform.position);

        stats.Velocity = velocity;
        
    }

}
