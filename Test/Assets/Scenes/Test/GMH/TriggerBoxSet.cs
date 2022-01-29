using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxSet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;
    public Vector3 offset;
    void Start()
    {
        transform.localScale = transform.transform.localScale * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
