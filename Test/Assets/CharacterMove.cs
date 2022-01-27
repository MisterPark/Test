using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody characterRigidbody;
    private Animator characterAnimator;
    // Start is called before the first frame update
    void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();
        characterAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        float fallSpeed = characterRigidbody.velocity.y;

        Vector3 velocity = new Vector3(inputX, 0, inputZ);
        velocity *= speed;
        if (velocity.magnitude != 0)
        {
            transform.LookAt(transform.position+velocity);
        }
        characterAnimator.SetFloat("Velocity", velocity.magnitude);
        velocity.y = fallSpeed;
        characterRigidbody.velocity = velocity;
    }
}
