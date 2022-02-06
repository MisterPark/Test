using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirctionToTarget : MonoBehaviour
{
    public GameObject Target;

    Vector3 direction;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance < 3)
        {
            direction = Target.transform.position - transform.position;
            direction.Normalize();
            direction.y = 0;
            transform.forward = direction;
        }

    }
}
