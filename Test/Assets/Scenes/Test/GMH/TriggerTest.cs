using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public GameObject target;

    private bool isTrigger;
    public bool IsTrigger { get { return isTrigger; } private set { isTrigger = value; } }

    MeshRenderer mesh;
    Material mat;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
        direction = Vector3.forward;
        isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerSample")
        {
            mat.color = new Color(0, 0, 0, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.forward = direction;
        isTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "PlayerSample")
        {
            mat.color = new Color(1, 1, 1, 0);
            isTrigger = false;
        }
    }


}
