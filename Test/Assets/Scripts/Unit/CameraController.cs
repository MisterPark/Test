using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*[SerializeField] */GameObject player;
    [SerializeField] Vector3 offset = new Vector3(0, 1.5f, 0);
    [SerializeField] float rotateSpeed = 2.5f;
    [SerializeField] float interval = 1.6f;
    private float xRotate = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
        transform.position = (player.transform.position + offset) - (transform.forward * interval);   
    }
}
