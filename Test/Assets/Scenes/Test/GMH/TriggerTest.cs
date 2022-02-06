using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    GameObject player;

    MeshRenderer mesh;
    Material mat;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        direction = Vector3.forward;
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            mat.color = new Color(0, 0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
      
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            mat.color = new Color(1, 1, 1, 0);
        }
    }


}
