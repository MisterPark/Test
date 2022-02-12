using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi_02 : MonsterController
{

    [SerializeField] List<GameObject> projectiles;
    private List<GameObject> projectileList = new List<GameObject>();
    // Start is called before the first frame update
    protected void OnEnable()
    {
        base.OnEnable();
    }
    protected void OnDisable()
    {
        base.OnDisable();
    }

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override bool Attack()
    {
        base.Attack();
        DirectedToPlayer();
        if (animator.GetInteger("Attack") == -1)
        {
            animator.SetInteger("Attack", 0);
            int index = Random.Range(0, projectiles.Count - 1);
            Debug.Log(projectiles.Count);
            GameObject gameObject = ObjectPool.Instance.Allocate(projectiles[index].name);
            if (gameObject == null)
            {
                Debug.LogError("can't find GameObject");
                return false;
            }
            Arrow projectile = gameObject.GetComponent<Arrow>();
            if(projectile == null)
            {
                Debug.LogError("can't find Projectile");
                return false;
            }
            projectile.shooter = this;
            //projectile.target = target;
            projectile.target = GameObject.Find("Player");
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            
            gameObject.transform.forward = transform.forward;
            projectileList.Add(gameObject);
        }

        return true;
    }

    public void Remove(GameObject gameObject)
    {
        ObjectPool.Instance.Free(gameObject);
        projectileList.Remove(gameObject);
    }

}
