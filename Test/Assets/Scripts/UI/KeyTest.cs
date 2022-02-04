using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTest : MonoBehaviour
{
    public MessageBox TempCanvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TempCanvas.Show("굳건이", "높은산 깊은 골 적막한 산하 눈내린 전선을 우리는 간다~" , 5f);
        }
    }
}
