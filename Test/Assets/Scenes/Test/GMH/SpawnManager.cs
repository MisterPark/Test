using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private class PoolItem
    {
        public bool isActive;
        public GameObject gameObject;
    }

    public int maxCount = 5;
    public int monsterCount;

    public float spawnTime;
    public float curTime;

    public Transform[] spawnPoints;
    public bool[] isSpawn;

    private static SpawnManager _instance;

    public static SpawnManager Instance { 
        get {
            if (_instance == null)
                throw new System.Exception("Faild to Initialize");
            return _instance;
        } 
    }

    public int activeCount;

    public GameObject poolObject;
    private List<PoolItem> poolItemList;

    private void Awake()
    {
        if(_instance == null)    
            _instance= this;
    }
    private void Start()
    {
        
        monsterCount = 0;
        activeCount = 0;

        poolItemList = new List<PoolItem>();

        InstantiateObjects();


        isSpawn = new bool[spawnPoints.Length];
        for(int i = 0; i <isSpawn.Length; i++)
        {
            isSpawn[i] = false;
        }
    }

    public void Update()
    {
        
        
        if (curTime >= spawnTime && maxCount > activeCount)
        {
            ActivatePoolItem();
            int x = Random.Range(0, spawnPoints.Length);
        }
        curTime += Time.deltaTime;
    }

    public void InstantiateObjects()
    {
        maxCount = spawnPoints.Length;
        for (int i = 0; i < spawnPoints.Length; ++i)
        {
            PoolItem poolItem = new PoolItem();

            poolItem.isActive = false;
            poolItem.gameObject = GameObject.Instantiate(poolObject,spawnPoints[i]);
            poolItem.gameObject.SetActive(true);
            activeCount++;
            monsterCount++;
            poolItemList.Add(poolItem);
        }
    }


    public GameObject ActivatePoolItem()
    {
        if (poolItemList == null) return null;
        

        int count = poolItemList.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];
            if (!poolItem.isActive)
            {
                activeCount++;
                monsterCount++;
                poolItem.isActive = true;
                poolItem.gameObject.SetActive(true);
                
                return poolItem.gameObject;
            }
        }

        return null;
    }
    public void DeactivatePoolItem(GameObject removeObject)
    {
        if (poolItemList == null || removeObject == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];
            if (poolItem.gameObject == removeObject)
            {
                activeCount--;

                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);

                return;
            }
        }
    }
    public void DeActivateAllPoolItems()
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; ++i)
        {
            PoolItem poolItem = poolItemList[i];

            if (poolItem.gameObject != null && poolItem.isActive == true)
            {
                poolItem.isActive = false;
                poolItem.gameObject.SetActive(false);
            }
        }
        activeCount = 0;
    }
}

