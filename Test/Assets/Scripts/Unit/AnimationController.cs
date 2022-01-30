using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    UnitStat stats;
    Animator animator;
    void Start()
    {
        stats = GetComponent<UnitStat>();
        animator = (transform.Find("Mesh").gameObject).transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //float inputX = Input.GetAxis("Horizontal");
        //float inputZ = Input.GetAxis("Vertical");


        //Vector3 velocity = new Vector3(inputX, 0, inputZ);
        //velocity *= stats.MoveSpeed;
        //if (velocity.magnitude != 0)
        //{
        //    transform.LookAt(transform.position + velocity);
        //}
        //animator.SetFloat("Velocity", velocity.magnitude);

    }

    private void LateUpdate()
    {
        if (stats.Velocity.magnitude != 0)
        {
            transform.LookAt(transform.position + stats.Velocity);
        }
        animator.SetFloat("Velocity", stats.Velocity.magnitude);

        animator.SetBool("Jump", stats.JumpCheck);
        Debug.Log(stats.JumpCheck);
    }
}
