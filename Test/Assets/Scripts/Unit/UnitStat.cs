using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStat : MonoBehaviour
{
    [SerializeField] public float MaxHp;
    [SerializeField] public float Hp;
    [SerializeField] public float MaxMp;
    [SerializeField] public float Mp;
    [SerializeField] public float AttackDamage;
    [SerializeField] public float AttackSpeed;

    [SerializeField] public float MoveSpeed;
    [SerializeField] public float JumpPower;
    public Vector3 Velocity;
}
