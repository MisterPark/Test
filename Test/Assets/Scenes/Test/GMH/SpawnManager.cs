using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int maxCount;
    public int monsterCount;
    public float spawnTime;
    public float curTime;
    public Transform[] spawnPoints;
    public bool[] isSpawn;
    public GameObject monster;

    public static SpawnManager _instance;

    private void Start()
    {
        isSpawn = new bool[spawnPoints.Length];
        for(int i = 0; i <isSpawn.Length; i++)
        {
            isSpawn[i] = false;
        }
        _instance = this;
    }

    public void Update()
    {
        if (curTime >= spawnTime&&maxCount>monsterCount)
        {
            int x = Random.Range(0,spawnPoints.Length);
            if(!isSpawn[x])
            SpawnMonster(x);
        }
        curTime += Time.deltaTime;
    }

    public void SpawnMonster(int ranNum)
    {
        curTime = 0;
        monsterCount++;
        Instantiate(monster,spawnPoints[ranNum]);
        isSpawn[ranNum] = true; 
    }
}
