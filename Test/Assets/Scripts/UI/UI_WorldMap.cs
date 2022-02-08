using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WorldMap : MonoBehaviour
{
    public GameObject WorldMapPanel;

    private bool isOpen = false;
    private float scale = 0f;
    private float scaleMax = 1f;
    private float scaleMin = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseScrollY = Input.mouseScrollDelta.y;
        if (Input.GetKeyDown(KeyCode.M))
        {
            WorldMapPanel.SetActive(!WorldMapPanel.activeSelf);
        }
        if(WorldMapPanel.activeSelf)
        {
            if(Input.GetKey(KeyCode.W))
            {
                WorldMapPanel.transform.Translate(0f, 1f  * 5f * Time.deltaTime , 0f);
            }
            if (mouseScrollY > 0f)
            {
                scale += mouseScrollY  * 0.1f* Time.deltaTime;
                if (scale <= scaleMin)
                    scale = scaleMin;
                WorldMapPanel.transform.localScale = new Vector3(scale, scale, scale);
            }
            if (mouseScrollY < 0f)
            {
                scale -= mouseScrollY * 0.1f * Time.deltaTime;
                if (scale >= scaleMax)
                    scale = scaleMax;
                WorldMapPanel.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}
