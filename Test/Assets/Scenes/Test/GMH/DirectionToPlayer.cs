using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionToPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Box;
    Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        direction = Player.transform.position - transform.position;
        direction.Normalize();
        direction.y = 0;
        transform.forward=direction;
    }
}
