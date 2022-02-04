using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerSample : MonoBehaviour
{
    PlayerStatSample stats;
    void Start()
    {
        stats = GetComponent<PlayerStatSample>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        // Rotate
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= stats.MoveSpeed;
        if (velocity.magnitude != 0)
        {
            transform.LookAt(transform.position + velocity);
        }

        Vector3 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction = transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction = (transform.forward + Vector3.left);

        }
        if (Input.GetKey(KeyCode.S))
        {
            direction = (transform.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = (transform.forward + Vector3.right);
        }
        // Move
        direction.Normalize();
        //Debug.Log(direction);
        transform.position += stats.MoveSpeed * direction * Time.deltaTime;
    }
}
