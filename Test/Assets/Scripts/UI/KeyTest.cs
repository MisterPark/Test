using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTest : MonoBehaviour
{
    public MessageBox TempCanvas;
    public UI_Crosshair TempCross;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TempCanvas.Show("������", "������ ���� �� ������ ���� ������ ������ �츮�� ����~", 5f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TempCross.Show(false);
        }
    }
}
