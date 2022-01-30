using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*[SerializeField] */GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 1.5f, 0);
    [SerializeField] float rotateSpeed = 2.5f;
    [SerializeField] float zoom = 1.6f;
    private float xRotate = 0f;

    ////[SerializeField] Texture2D cursorTexture;
    //private Vector2 cursorHotSpot;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
        //cursorHotSpot.x = cursorTexture.width / 2;
        //cursorHotSpot.y = cursorTexture.height / 2;
        //Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.ForceSoftware);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Zoom();
    }
    

    void Move()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * rotateSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * rotateSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        transform.position = (player.transform.position + offset) - (transform.forward * zoom);   
    }

    void Zoom()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel") * 1.2f;
        zoom -= wheel;
        if (zoom < 0.8f)
            zoom = 0.8f;
        else if (zoom > 3f)
            zoom = 3f;
    }
}
