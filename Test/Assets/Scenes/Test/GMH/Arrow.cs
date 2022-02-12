using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;
    public MonsterAi_02 shooter;
    public GameObject target { get; set; }

    Vector3 targetPosition;
    public float yOffset=0.8f;
    float speed;
    float delay;
    float tick;
    float yspeed=1f;
    public float flightTime = 5f;

    private Rigidbody projectile;


    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        speed = 10f;
        tick = 0;
        delay = 5f;
        targetPosition =target.transform.position;
        targetPosition.y += yOffset;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        tick += Time.deltaTime;
        if(tick>delay)
        {
            gameObject.SetActive(false);
            tick = 0;
            yspeed = 1f;
        }
    }

    private void OnDisable()
    {
    }

    void Move()
    {
        float gravity = 4f;
        Vector3 direction = targetPosition - transform.position;
        float parabolaTime = direction.magnitude / (speed * Time.deltaTime);

        yspeed = yspeed - gravity * Time.deltaTime;
        float Tempy = yspeed * Time.deltaTime * parabolaTime;
        direction.y = 0;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime + new Vector3(0f, Tempy, 0f);
    }

    //void LaunchProjectile()
    //{
    //    Vector3 vo = CalculateVelocty(targetPosition, shooter.transform.position, flightTime);
    //}

    //Vector3 CalculateVelocty(Vector3 target, Vector3 origin, float time)
    //{
    //    Vector3 distance = target - origin;
    //    Vector3 distanceXz = distance;
    //    distanceXz.y = 0f;

    //    float sY = distance.y;
    //    float sXz = distanceXz.magnitude;

    //    float Vxz = sXz / time;
    //    float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

    //    Vector3 result = distanceXz.normalized;
    //    result *= Vxz;
    //    result.y = Vy;

    //    return result;
    //}

    //Vector3 CalculatePosInTime(Vector3 vo, float time)
    //{
    //    Vector3 Vxz = vo;
    //    Vxz.y = 0f;

    //    Vector3 result = shooter.transform.position + vo * time;
    //    float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + shooter.transform.position.y;

    //    result.y = sY;

    //    return result;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Player")
    //    { shooter.Remove(this.gameObject); }  
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Player"||collision.gameObject.name=="Terrain")
    //    { shooter.Remove(this.gameObject); }
    //}
    
}
