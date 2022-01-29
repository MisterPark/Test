using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;
    public float Pitch;
    public float Yaw;

    //public float delayTime;
    void Start()
    {
        transform.Rotate(Pitch, Yaw, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 FixedPos = new Vector3(target.transform.position.x + offsetX, target.transform.position.y + offsetY, target.transform.position.z + offsetZ);
        transform.position = FixedPos;
        //transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * delayTime);
    }
}
