using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjectController : UnitController
{
    [HideInInspector] public float lifeTime;
    List<GameObject> DamagedList =  new List<GameObject>();
    [HideInInspector] public GameObject host;
    //static protected GameObject damageObject = Resources.Load("DamageObject/DamageObject") as GameObject;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        Unit otherUnit = other.gameObject.GetComponent<Unit>();
        if (otherUnit == null)
            return;

        if (stats.team == otherUnit.stats.team || UnitStat.Team.Natural == otherUnit.stats.team)
            return;
        if (otherUnit.stats.Hp <= 0f)
            return;

        foreach (GameObject damaged in DamagedList)
        {
            if (damaged == other.gameObject)
                return;
        }

        float damage = stats.AttackDamage;
        damage = otherUnit.controller.Damaged(host, gameObject, damage);
        otherUnit.stats.Hp -= damage;
        DamagedList.Add(other.gameObject);
    }

    void Test()
    {
        lifeTime = 30f;
        stats.AttackDamage = 100f;
        stats.team = UnitStat.Team.Enemy;
    }

    public static void Create_DamageObject(GameObject _host, UnitStat.Team _team, Vector3 _pos, float _scale, float _lifeTime, float _damage)
    {
        GameObject newDamageObject = Instantiate(Resources.Load("DamageObject/DamageObject")) as GameObject;
        newDamageObject.transform.position = _pos;
        newDamageObject.transform.localScale = new Vector3( _scale,_scale,_scale);
        Unit newDamageObjectUnit = newDamageObject.GetComponent<Unit>();
        newDamageObjectUnit.stats.team = _team;
        newDamageObjectUnit.stats.AttackDamage = _damage;
        DamageObjectController newDamageObjectController = newDamageObject.GetComponent<DamageObjectController>();
        newDamageObjectController.host = _host;
        newDamageObjectController.lifeTime = _lifeTime;

    }
}
