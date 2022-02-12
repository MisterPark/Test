using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Crosshair : MonoBehaviour
{
    public Image CrossImage;
    // Start is called before the first frame update
    void Start()
    {
        Color TempColor = CrossImage.color;
        TempColor.a = 0f;
        CrossImage.color = TempColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(bool bshow)
    {
        Color TempColor = CrossImage.color;
        if (bshow)
        {
            TempColor.a = 1f;
        }
        else
        {
            TempColor.a = 0f;
        }
        CrossImage.color = TempColor;
    }
}
