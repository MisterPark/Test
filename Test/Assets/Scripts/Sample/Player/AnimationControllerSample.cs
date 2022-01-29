using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerSample : MonoBehaviour
{
    Animator animator;
    PlayerStatSample stats;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        stats = GetComponent<PlayerStatSample>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");


        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= stats.MoveSpeed;
        if (velocity.magnitude != 0)
        {
            transform.LookAt(transform.position + velocity);
        }
        animator.SetFloat("Velocity", velocity.magnitude);
    }
}
