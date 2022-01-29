using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonSample : MonoBehaviour
{
    public static SingletonSample Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
