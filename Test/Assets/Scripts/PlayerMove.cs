using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public class PlayerSpeedValue
    {
        public float speed;
        public float jumpPower;
    }
    PlayerSpeedValue playerSpeedValue;
    float moveAccelTime = 1f;
    float moveAccelDelay = 0f;
    
    private Rigidbody rigidbody;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeedValue = new PlayerSpeedValue();
        playerSpeedValue.speed = 4f;
        playerSpeedValue.jumpPower = 15f;
        rigidbody = GetComponent<Rigidbody>();
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0f, -15f, 0f);
        Move();
    }

    void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 velocity = (new Vector3(inputX, 0, inputZ).normalized) * playerSpeedValue.speed;

        float fallSpeed = rigidbody.velocity.y;
        float velocityMag = velocity.magnitude;
        Jump(fallSpeed);


            if (velocityMag != 0)
        {
            transform.LookAt(transform.position + velocity);
        }

        // °¡¼Óµµ
        if(velocityMag >  playerSpeedValue.speed * 0.9f)
        {
            if (moveAccelDelay < 1f)
            {
                moveAccelDelay += Time.deltaTime;
            }
            else
            {
                if (moveAccelTime < 2f)
                    moveAccelTime += Time.deltaTime * 0.5f;
            }
        }
        else
        {
            moveAccelTime = 1f;
            moveAccelDelay = 0f;
        }

        animator.SetFloat("Velocity", velocityMag * moveAccelTime);
        velocity.y = fallSpeed;
        velocity.x *= moveAccelTime;
        velocity.z *= moveAccelTime;
        rigidbody.velocity = velocity;
    }
    void Jump(float fallSpeed)
    {
        if (fallSpeed < 1f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector3.up * playerSpeedValue.jumpPower, ForceMode.Impulse);
            }
        }
    }
}
