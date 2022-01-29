using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertySample : MonoBehaviour
{
    public float Speed { get; set; } // ตัดู public

    public float Sp { get; private set; } // public get private set

    int b;
    int c;
    int a;
    public int A
    {
        get
        {
            int temp = a + b + c;
            return temp;
        }

        set
        {
            a = value * 2;
        }
    }

    void Start()
    {
        A = 10;
    }

    void Update()
    {

    }
}
