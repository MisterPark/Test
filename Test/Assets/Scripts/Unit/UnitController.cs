using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    // Start is called before the first frame update
    public UnitStat stats { get; set; }
    private Rigidbody rigidbody;
    protected virtual void Start()
    {
        stats = GetComponent<UnitStat>();
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    
}
