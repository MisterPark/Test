using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public Spawner Spawner { get; set; }
    float test;
    private Vector3 firstPosition;
    public int hp = 3;
    private void Update()
    {
        if( hp<=0)
        {
            //SpawnManager.Instance.activeCount--;
            //SpawnManager.Instance.monsterCount--;
            //hp = 3;
            //transform.position = firstPosition;
            //SpawnManager.Instance.DeactivatePoolItem(gameObject);
            //SpawnManager.Instance.curTime = 0;
            //SpawnManager.Instance.isSpawn[int.Parse(transform.parent.name)-1] = false;

            
        }
        test += Time.deltaTime;

        if (test > 5)
        {
            hp -= 1;
            test = 0;
            Spawner.Remove(this.gameObject);
            
        }
    }

    private void Start()
    {
        firstPosition = transform.position;
        
    }

    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }
    

}
