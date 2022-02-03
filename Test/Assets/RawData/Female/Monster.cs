using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if( hp<=0)
        {
            SpawnManager._instance.monsterCount--;
            SpawnManager._instance.isSpawn[int.Parse(transform.parent.name)-1] = false;
            Destroy(this.gameObject);
        }
    }

    public int hp = 3;
    
    public void TakeDamage(int damage)
    {
        hp = hp - damage;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
}
