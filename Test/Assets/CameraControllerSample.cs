using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerSample : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {


        transform.position = player.transform.position + offset;
        Vector3 lookTarget = player.transform.position + new Vector3(0, 1.5f, 0);
        Vector3 direction = lookTarget - transform.position;
        direction.Normalize();
        transform.forward = direction;
        
    }
}
