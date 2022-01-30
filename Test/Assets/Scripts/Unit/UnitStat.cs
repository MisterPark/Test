using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStat : MonoBehaviour
{
    public enum State { Idle, Run, Jump }
    State state { get; set; }
    public bool JumpCheck;
    [SerializeField] public float MaxHp;
    [SerializeField] public float Hp;
    [SerializeField] public float MaxMp;
    [SerializeField] public float Mp;
    [SerializeField] public float AttackDamage;
    [SerializeField] public float AttackSpeed;

    [SerializeField] public float MoveSpeed;
    [SerializeField] public float JumpPower;
    public Vector3 Velocity;

    private void Start()
    {
        Hp = MaxHp;
        Mp = MaxMp;
    }
}
