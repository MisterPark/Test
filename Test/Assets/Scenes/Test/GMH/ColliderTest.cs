using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    
    MeshRenderer mesh;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position += transform.up;
    }
}
