using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> prefabs;
    [SerializeField] float radius;
    List<GameObject> spawnList = new List<GameObject>();
    float delay = 0.1f;
    float tick = 0;


    void Start()
    {
        
    }

    public void Spawn()
    {
        float distance = Random.Range(0, radius);
        float angle = Random.Range(0, 360);
        Quaternion quaternion = Quaternion.Euler(0, angle, 0);
        Vector3 direction = quaternion* transform.forward* distance;
        Vector3 randPos = transform.position + direction;
        
        int index = Random.Range(0, prefabs.Count - 1);

        
        GameObject gameObject = ObjectPool.Instance.Allocate(prefabs[index].name);
        gameObject.transform.position = randPos;
        
        spawnList.Add(gameObject);
    }

    
    // Update is called once per frame
    void Update()
    {
        tick+=Time.deltaTime;
        if(tick >= delay)
        {
            tick = 0;
            Spawn();
        }
    }
}
