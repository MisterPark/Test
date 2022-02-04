using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    public const float minZoom = 0.8f;
    public const float maxZoom = 3f;
    [SerializeField] float rotateSpeed = 2.5f;
    [SerializeField] float zoom = 1.6f;
    private float xRotate = 0f;
    Vector3 offset = new Vector3(0f, 1f, 0f);

    void Start()
    {
        player = GameObject.Find("Player");
        Cursor_Visible(false);
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
        if (Input.GetKeyDown(KeyCode.T))
            Cursor_Visible(true);
        if (Input.GetKeyDown(KeyCode.Y))
            Cursor_Visible(false);
    }

    void Move()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * rotateSpeed;
        //
        float maxRocateSpeed = 0.4f; // 최대줌에서 회전속도율, 작을수록 빠르게
        yRotateSize *= 1f - (((zoom - minZoom) * maxRocateSpeed) / (maxZoom - minZoom));
        //
        float xRotateSize = -Input.GetAxis("Mouse Y") * rotateSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        transform.position = player.transform.position + offset - (transform.forward * zoom);
    }

    void Zoom()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel") * 1.2f;
        float zoom = this.zoom;
        zoom -= wheel;

        zoom = (zoom < minZoom) ? minZoom : zoom;
        zoom = (zoom > maxZoom) ? maxZoom : zoom;

        this.zoom = zoom;
    }

    public void Cursor_Visible(bool _visible)
    {
        //Cursor.lockState = CursorLockMode.None;
        if (_visible)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
