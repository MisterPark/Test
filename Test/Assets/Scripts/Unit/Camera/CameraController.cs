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

    private Camera cameraCom;
    private float povSetSpeed = 10f;
    private float cameraMaxPov = 60f;
    private float cameraCurrentPov = 60f;

    private static CameraController _instance;

    public static CameraController Instance
    {
        get
        {
            if (_instance == null)
                throw new System.Exception("Faild to Initialize");
            return _instance;
        }
    }
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
    void Start()
    {
        player = GameObject.Find("Player");
        Cursor_Visible(false);
        cameraCom = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        Move();
        Zoom();
        Pov();
        if (Input.GetKeyDown(KeyCode.T))
            Cursor_Visible(true);
        if (Input.GetKeyDown(KeyCode.Y))
            Cursor_Visible(false);
    }

    void Move()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * rotateSpeed;
        //
        float maxRocateSpeed = 0.4f; // �ִ��ܿ��� ȸ���ӵ���, �������� ������
        yRotateSize *= 1f - (((zoom - minZoom) * maxRocateSpeed) / (maxZoom - minZoom));
        //
        float xRotateSize = -Input.GetAxis("Mouse Y") * rotateSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ���� (-45:�ϴù���, 80:�ٴڹ���)
        // Clamp �� ���� ������ �����ϴ� �Լ�
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

    public void Pov()
    {
        if (cameraCurrentPov < cameraMaxPov)
        {
            cameraCom.fieldOfView += povSetSpeed * Time.deltaTime;
            if (cameraCom.fieldOfView >= cameraMaxPov)
                cameraCom.fieldOfView = cameraMaxPov;
            cameraCurrentPov = cameraCom.fieldOfView;
        }
        else if (cameraCurrentPov > cameraMaxPov)
        {
            cameraCom.fieldOfView -= (povSetSpeed * 0.8f) * Time.deltaTime;
            if (cameraCom.fieldOfView <= cameraMaxPov)
                cameraCom.fieldOfView = cameraMaxPov;
            cameraCurrentPov = cameraCom.fieldOfView;
        }
        
    }

    public void Set_Pov(float _pov = 60f, float _povSetSpeed = 20f)
    {
        cameraMaxPov = _pov;
        povSetSpeed = _povSetSpeed;
    }
}
