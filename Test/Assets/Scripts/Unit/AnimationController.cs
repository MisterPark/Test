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

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        animator.SetFloat("Velocity", velocity.magnitude);
        animator.SetBool("Jump", stats.JumpCheck);
        Debug.Log(stats.JumpCheck);
    }

}
