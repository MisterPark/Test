using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WorldMap : MonoBehaviour
{
    public GameObject WorldMapPanel;

    private float scale = 1f;
    private float scaleMax = 5f;
    private float scaleMin = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float mouseScrollY = Input.mouseScrollDelta.y;
        float speed = 15f;
        if (Input.GetKeyDown(KeyCode.M))
        {
            WorldMapPanel.SetActive(!WorldMapPanel.activeSelf);
        }
        if(WorldMapPanel.activeSelf)
        {
            //Move
            Vector2 displaySize = new Vector2(1920f, 1080f);
            float maxHor = displaySize.x * 0.5f * (scale - 1) / scale;
            float maxVer = displaySize.y * 0.5f * (scale - 1) / scale;
            Vector3 localPos = WorldMapPanel.transform.localPosition;
            Debug.Log(maxHor.ToString());
            if (localPos.x > maxHor)
                if (hor > 0f)
                    hor = 0f;
            if (localPos.x < maxHor * -1f)
                if (hor < 0f)
                    hor = 0f;
            if (localPos.y > maxVer)
                if (ver > 0f)
                    ver = 0f;
            if (localPos.y < maxVer * -1f)
                if (ver < 0f)
                    ver = 0f;
            WorldMapPanel.transform.Translate(hor * speed * Time.deltaTime, ver * speed * Time.deltaTime, 0f);

            //Zoom In/Out
            if (mouseScrollY > 0f)
            {
                scale += mouseScrollY * 5f * Time.deltaTime;
                if (scale >= scaleMax)
                    scale = scaleMax;
                WorldMapPanel.transform.localScale = new Vector3(scale, scale, scale);
            }
            if (mouseScrollY < 0f)
            {
                scale += mouseScrollY * 5f * Time.deltaTime;
                if (scale <= scaleMin)
                    scale = scaleMin;
                WorldMapPanel.transform.localScale = new Vector3(scale, scale, scale);
            }
        }
    }
}
