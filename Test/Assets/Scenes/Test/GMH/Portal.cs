using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    GameObject player;
    public Vector3 toPosition;
    public float portalCount = 2;

    float moveCount;
    // Start is called before the first frame update
    void Start()
    {
        moveCount = 0;
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            moveCount += Time.deltaTime;
            if(moveCount > portalCount)
            {
                other.transform.position = toPosition;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            moveCount = 0;
        }
    }


}
