using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionToPlayer : MonoBehaviour
{
    GameObject player;
    
    Vector3 direction;
    float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 3)
        {
            direction = player.transform.position - transform.position;
            direction.Normalize();
            direction.y = 0;
            transform.forward = direction;
        }
    }
}
