using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WorldMap : MonoBehaviour
{
    public GameObject WorldMapPanel;
    public GameObject outline;
    public GameObject outlineText;
    public GameObject centerCursor;

    private float scale = 1f;
    private float scaleMax = 5f;
    private float scaleMin = 1f;

    // Start is called before the first frame update
    void Start()
    {
        outline.GetComponent<RectTransform>().sizeDelta = transform.GetComponent<RectTransform>().sizeDelta;
        InitOutlineSize();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float mouseScrollY = Input.mouseScrollDelta.y;
        float speed = 30f;
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
            if(Input.GetKey(KeyCode.W))
            {
                if(localPos.y < maxVer)
                    WorldMapPanel.transform.Translate(0f, speed * scale * Time.deltaTime, 0f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                if (localPos.y > -maxVer)
                    WorldMapPanel.transform.Translate(0f, -speed* scale * Time.deltaTime, 0f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                if(localPos.x > -maxHor)
                    WorldMapPanel.transform.Translate(-speed * scale * Time.deltaTime, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (localPos.x < maxHor)
                    WorldMapPanel.transform.Translate(speed * scale * Time.deltaTime, 0f, 0f);
            }

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

    private void InitOutlineSize()
    {
        Vector2 displaySize = transform.GetComponent<RectTransform>().sizeDelta;
        float size = displaySize.y * 0.0925f * 0.5f;
        outlineText.transform.localPosition = new Vector3(displaySize.x / 6f, displaySize.y * -0.5f + size);
    }
}
