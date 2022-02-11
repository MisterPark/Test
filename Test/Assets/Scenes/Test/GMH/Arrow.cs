using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;
 
    public MonsterAi_02 shooter;
    
    float speed;
    float delay;
    float tick;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        tick = 0;
        delay = 5f;
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
        }
    }

    private void OnDisable()
    {
        shooter.Remove(this.gameObject);
    }

    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        { shooter.Remove(this.gameObject); }
    }

}
