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
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            animator.SetFloat("Velocity", 1f);
        else
            animator.SetFloat("Velocity", 0f);
        /*
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        animator.SetFloat("Velocity", velocity.magnitude * 100f);
        */

        animator.SetBool("Jump", stats.JumpCheck);

        Test();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            animator.SetBool("ToLand", true);
        }
    }

    void Test()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("JumpEnd") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            animator.SetBool("MovePossible", true);
    }
}
