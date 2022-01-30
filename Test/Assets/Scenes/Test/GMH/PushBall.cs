using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBall : MonoBehaviour
{
    public float force=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
            transform.position += collision.gameObject.transform.forward * force * Time.deltaTime;
    }
}
