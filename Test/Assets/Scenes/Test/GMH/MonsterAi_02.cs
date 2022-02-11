using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi_02 : MonsterController
{

    [SerializeField] List<GameObject> arrows;
    List<GameObject> arrowList;
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
            int index = Random.Range(0, arrows.Count - 1);
            GameObject gameObject = ObjectPool.Instance.Allocate(arrows[index].name);
            if (gameObject == null)
            {
                Debug.LogError("can't find GameObject");
                return false;
            }
            Arrow arrow = gameObject.GetComponent<Arrow>();
            if(arrow == null)
            {
                Debug.LogError("can't find Arrow");
                return false;
            }
            arrow.shooter = this;
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+0.5f,transform.position.z);
            
            gameObject.transform.forward = transform.forward;
            arrowList.Add(gameObject);
        }

        return true;
    }

    public void Remove(GameObject gameObject)
    {
        ObjectPool.Instance.Free(gameObject);
        arrowList.Remove(gameObject);
    }

}
