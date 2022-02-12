using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAi_01 : MonsterController
{



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
            Vector3 tempPos = gameObject.transform.position + (gameObject.transform.forward * AttackRange);
            tempPos.y += 0.7f;
            DamageObjectController.Create_DamageObject(gameObject,UnitStat.Team.Enemy, tempPos, 0.5f, 1.2f, 15f);
        }
        return true;
    }
}
