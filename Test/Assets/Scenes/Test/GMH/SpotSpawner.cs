using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;    
    List<GameObject> spawnList = new List<GameObject>();
    float delay = 0.1f;
    float tick = 0;
    
    [SerializeField]int spawnCount;

    public Transform[] spawnPoints;
    

    
    private void Start()
    {      
    }

    public void Update()
    {
        for(int i = 0; i <  spawnPoints.Length;i++)
        {
            if(spawnPoints[i] == null)
                this.gameObject.SetActive(false);
        }

        if(spawnCount<spawnPoints.Length)
            Spawn();
        else if (spawnList.Count == 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void Spawn()
    {    
        int index = Random.Range(0, prefabs.Count - 1);

        GameObject gameObject = ObjectPool.Instance.Allocate(prefabs[index].name);
        if (gameObject == null)
        {
            Debug.LogError("can't find GameObject");
            return;
        }
        MonsterController monsterController = gameObject.GetComponent<MonsterController>();
        if (monsterController == null)
        {
            Debug.LogError("can't find MonsterController");
            return;
        }
        monsterController.spotSpawner = this;

        gameObject.transform.position = spawnPoints[spawnCount].transform.position;

        spawnCount++;
        
        spawnList.Add(gameObject);
    }

    public void Remove(GameObject gameObject)
    {
        ObjectPool.Instance.Free(gameObject);
        spawnList.Remove(gameObject);
    }

}

