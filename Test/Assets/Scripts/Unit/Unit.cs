using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [HideInInspector] public UnitController controller;
    public UnitStat stats { get; set; }

    private void Awake()
    {
        controller = GetComponent<UnitController>();
        stats = GetComponent<UnitStat>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
