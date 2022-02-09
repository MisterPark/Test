using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Status : MonoBehaviour
{
    [SerializeField]
    private GameObject statusWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (statusWindow.activeSelf == false)
                OnStatusWindow();
            else if (statusWindow.activeSelf == true)
                OffStatusWindow();
        }
    }

    public void OnStatusWindow()
    {
        statusWindow.SetActive(true);
    }

    public void OffStatusWindow()
    {
        statusWindow.SetActive(false);
    }
}
